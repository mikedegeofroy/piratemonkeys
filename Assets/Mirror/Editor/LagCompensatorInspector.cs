using Mirror.Components.LagCompensation;
using UnityEditor;

namespace Mirror.Editor
{
    [CustomEditor(typeof(LagCompensator))]
    public class LagCompensatorInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("Preview Component - Feedback appreciated on GitHub or Discord!", MessageType.Warning);
            DrawDefaultInspector();
        }
    }
}
