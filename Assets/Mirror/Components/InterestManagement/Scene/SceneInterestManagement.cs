using System.Collections.Generic;
using Mirror.Core;
using UnityEngine;

namespace Mirror.Components.InterestManagement.Scene
{
    [AddComponentMenu("Network/ Interest Management/ Scene/Scene Interest Management")]
    public class SceneInterestManagement : Core.InterestManagement
    {
        // Use Scene instead of string scene.name because when additively
        // loading multiples of a subscene the name won't be unique
        readonly Dictionary<UnityEngine.SceneManagement.Scene, HashSet<NetworkIdentity>> sceneObjects =
            new Dictionary<UnityEngine.SceneManagement.Scene, HashSet<NetworkIdentity>>();

        readonly Dictionary<NetworkIdentity, UnityEngine.SceneManagement.Scene> lastObjectScene =
            new Dictionary<NetworkIdentity, UnityEngine.SceneManagement.Scene>();

        HashSet<UnityEngine.SceneManagement.Scene> dirtyScenes = new HashSet<UnityEngine.SceneManagement.Scene>();

        [ServerCallback]
        public override void OnSpawned(NetworkIdentity identity)
        {
            UnityEngine.SceneManagement.Scene currentScene = identity.gameObject.scene;
            lastObjectScene[identity] = currentScene;
            // Debug.Log($"SceneInterestManagement.OnSpawned({identity.name}) currentScene: {currentScene}");
            if (!sceneObjects.TryGetValue(currentScene, out HashSet<NetworkIdentity> objects))
            {
                objects = new HashSet<NetworkIdentity>();
                sceneObjects.Add(currentScene, objects);
            }

            objects.Add(identity);
        }

        [ServerCallback]
        public override void OnDestroyed(NetworkIdentity identity)
        {
            // Don't RebuildSceneObservers here - that will happen in LateUpdate.
            // Multiple objects could be destroyed in same frame and we don't
            // want to rebuild for each one...let LateUpdate do it once.
            // We must add the current scene to dirtyScenes for LateUpdate to rebuild it.
            if (lastObjectScene.TryGetValue(identity, out UnityEngine.SceneManagement.Scene currentScene))
            {
                lastObjectScene.Remove(identity);
                if (sceneObjects.TryGetValue(currentScene, out HashSet<NetworkIdentity> objects) && objects.Remove(identity))
                    dirtyScenes.Add(currentScene);
            }
        }

        [ServerCallback]
        void LateUpdate()
        {
            // for each spawned:
            //   if scene changed:
            //     add previous to dirty
            //     add new to dirty
            foreach (NetworkIdentity identity in NetworkServer.spawned.Values)
            {
                if (!lastObjectScene.TryGetValue(identity, out UnityEngine.SceneManagement.Scene currentScene))
                    continue;

                UnityEngine.SceneManagement.Scene newScene = identity.gameObject.scene;
                if (newScene == currentScene)
                    continue;

                // Mark new/old scenes as dirty so they get rebuilt
                dirtyScenes.Add(currentScene);
                dirtyScenes.Add(newScene);

                // This object is in a new scene so observers in the prior scene
                // and the new scene need to rebuild their respective observers lists.

                // Remove this object from the hashset of the scene it just left
                sceneObjects[currentScene].Remove(identity);

                // Set this to the new scene this object just entered
                lastObjectScene[identity] = newScene;

                // Make sure this new scene is in the dictionary
                if (!sceneObjects.ContainsKey(newScene))
                    sceneObjects.Add(newScene, new HashSet<NetworkIdentity>());

                // Add this object to the hashset of the new scene
                sceneObjects[newScene].Add(identity);
            }

            // rebuild all dirty scenes
            foreach (UnityEngine.SceneManagement.Scene dirtyScene in dirtyScenes)
                RebuildSceneObservers(dirtyScene);

            dirtyScenes.Clear();
        }

        void RebuildSceneObservers(UnityEngine.SceneManagement.Scene scene)
        {
            foreach (NetworkIdentity netIdentity in sceneObjects[scene])
                if (netIdentity != null)
                    NetworkServer.RebuildObservers(netIdentity, false);
        }

        public override bool OnCheckObserver(NetworkIdentity identity, NetworkConnectionToClient newObserver)
        {
            return identity.gameObject.scene == newObserver.identity.gameObject.scene;
        }

        public override void OnRebuildObservers(NetworkIdentity identity, HashSet<NetworkConnectionToClient> newObservers)
        {
            if (!sceneObjects.TryGetValue(identity.gameObject.scene, out HashSet<NetworkIdentity> objects))
                return;

            // Add everything in the hashset for this object's current scene
            foreach (NetworkIdentity networkIdentity in objects)
                if (networkIdentity != null && networkIdentity.connectionToClient != null)
                    newObservers.Add(networkIdentity.connectionToClient);
        }
    }
}
