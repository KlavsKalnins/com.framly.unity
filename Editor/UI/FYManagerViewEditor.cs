using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Framly
{
    [CustomEditor(typeof(FYManagerView))]
    public class FYManagerViewEditor : Editor
    {
        public static FYManagerView manager; // should cache only once, see how Editor does it
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Generate Enum"))
            {
                GenerateEnums();
            }
            manager = (FYManagerView)target;
            DrawDefaultInspector();
        }

        [MenuItem("Framly/Generate/PanelType Enum")]
        public static void GenerateEnums()
        {
            manager = FindObjectOfType<FYManagerView>();
            List<string> enumList = new List<string>();
            for (int i = 0; i < manager.views.Length; i++)
            {
                if (manager.views[i] != null)
                    enumList.Add(manager.views[i].name);
            }
            FYEnumGenerator.CreateEnum("PanelType", enumList.ToArray());
        }
    }
}