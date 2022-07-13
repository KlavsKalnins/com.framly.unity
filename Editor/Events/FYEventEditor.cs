using UnityEditor;
using UnityEngine;

namespace Framly
{
    [CustomEditor(typeof(FYEvent), editorForChildClasses: true)]
    public class FYEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            FYEvent e = target as FYEvent;
            if (GUILayout.Button("Raise"))
                e.Raise();
        }
    }
}