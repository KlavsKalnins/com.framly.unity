using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Framly
{
    [CustomEditor(typeof(FYManagerUI))]
    public class ManagerUIEditor : Editor
    {
        public static FYManagerUI manager; // should cache only once, see how Editor does it
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Generate Enum"))
            {
                GenerateEnums();
            }
            manager = (FYManagerUI)target;
            DrawDefaultInspector();
        }

        [MenuItem("Framly/Generate/PanelType Enum")]
        public static void GenerateEnums()
        {
            manager = FindObjectOfType<FYManagerUI>();
            List<string> enumList = new List<string>();
            for (int i = 0; i < manager.ui.Length; i++)
            {
                if (manager.ui[i] != null)
                    enumList.Add(manager.ui[i].name);
            }
            FYEnumGenerator.CreateEnum("PanelType", enumList.ToArray());
        }
    }
}