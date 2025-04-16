using Mirror.Components.NetworkTransform;
using UnityEngine;

namespace Mirror.Examples._Common.Controllers.PlayerControllerRB
{
    [AddComponentMenu("Network/Player Controller RB (Unreliable)")]
    [RequireComponent(typeof(NetworkTransformUnreliable))]
    public class PlayerControllerRBUnreliable : PlayerControllerRBBase
    {
        protected override void OnValidate()
        {
            if (Application.isPlaying) return;
            base.OnValidate();

            Reset();
        }

        public override void Reset()
        {
            base.Reset();
            GetComponent<NetworkTransformUnreliable>().useFixedUpdate = true;
        }
    }
}
