using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Framly
{
    [CustomEditor(typeof(ManagerUI))]
    public class ManagerUIEditor : Editor
    {
        public static ManagerUI manager; // should cache only once, see how Editor does it
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Generate Enum"))
            {
                GenerateEnums();
            }
            manager = (ManagerUI)target;
            DrawDefaultInspector();
        }

        [MenuItem("Framly/Generate/PanelType Enum")]
        public static void GenerateEnums()
        {
            manager = FindObjectOfType<ManagerUI>();
            List<string> enumList = new List<string>();
            //string[] enumList = new string[manager.ui.Length];
            for (int i = 0; i < manager.ui.Length; i++)
            {
                if (manager.ui[i] != null)
                    enumList.Add(manager.ui[i].name);
            }
            EnumGenerator.CreateEnum("PanelType", enumList.ToArray());
        }
    }
}