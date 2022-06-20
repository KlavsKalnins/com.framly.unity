using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Framly
{
    [CustomEditor(typeof(FYPalette))]
    public class FYPaletteEditor : Editor
    {
        FYPalette manager;

        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Generate Palette Enum"))
            {
                CollectArrayNames();
            }
            DrawDefaultInspector();
            manager = (FYPalette)target;
        }
        [MenuItem("Framly/Generate/Palette Enum")]
        public static void CollectArrayNames()
        {
            var fieldInfo = typeof(FYPalette.ColorGroup).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            string[] enumList = new string[fieldInfo.Length];
            for (int i = 0; i < fieldInfo.Length; i++)
            {
                enumList[i] = fieldInfo[i].Name;
            }
            FYEnumGenerator.CreateEnum("ColorType", enumList);
        }
    }
}