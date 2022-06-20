using UnityEditor;
using UnityEngine;

namespace Framly
{
    [CustomEditor(typeof(FYGameEvent), editorForChildClasses: true)]
    public class FYEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            FYGameEvent e = target as FYGameEvent;
            if (GUILayout.Button("Raise"))
                e.Raise();
        }
    }
}