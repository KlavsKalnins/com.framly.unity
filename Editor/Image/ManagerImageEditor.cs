using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Framly
{
    [CustomEditor(typeof(ManagerImage))]
    public class ManagerImageEditor : Editor
    {
        public static ManagerImage manager;
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            manager = (ManagerImage)target;
            if (GUILayout.Button("Generate Image Component Enum"))
            {
                GenerateEnums();
            }
            if (GUILayout.Button("Set Sprites for Images"))
            {
                
                var items = Resources.FindObjectsOfTypeAll<SetImage>();
                foreach (var item in items)
                {
                    item.SetSprite(manager.imageComponets[(int)item.imageComponent].sprite);
                }
                
            }
            SceneView.RepaintAll();
            UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
        }
        [MenuItem("Framly/Generate/Image Component Enum")]
        public static void GenerateEnums()
        {
            manager = FindObjectOfType<ManagerImage>();
            List<string> enumList = new List<string>();
            for (int i = 0; i < manager.imageComponets.Length; i++)
            {
                if (manager.imageComponets[i].name != null)
                    enumList.Add(manager.imageComponets[i].name);
            }
            EnumGenerator.CreateEnum("ImageComponent", enumList.ToArray());
        }
    }
}