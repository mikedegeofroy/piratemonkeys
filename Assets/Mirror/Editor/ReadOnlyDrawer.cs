using Mirror.Core;
using UnityEditor;
using UnityEngine;

namespace Mirror.Editor
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Cache the current GUI enabled state
            bool prevGuiEnabledState = GUI.enabled;

            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = prevGuiEnabledState;
        }
    }
}
