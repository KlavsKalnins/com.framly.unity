using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Framly
{
    [CustomEditor(typeof(Palette))]
    public class PaletteEditor : Editor
    {
        Palette manager;

        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Generate Palette Enum"))
            {
                CollectArrayNames();
            }
            DrawDefaultInspector();
            manager = (Palette)target;
        }
        [MenuItem("Framly/Generate/Palette Enum")]
        public static void CollectArrayNames()
        {
            var fieldInfo = typeof(Palette.ColorGroup).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            string[] enumList = new string[fieldInfo.Length];
            for (int i = 0; i < fieldInfo.Length; i++)
            {
                enumList[i] = fieldInfo[i].Name;
            }
            EnumGenerator.CreateEnum("ColorType", enumList);
        }
    }
}