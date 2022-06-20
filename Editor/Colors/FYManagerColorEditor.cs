using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Framly
{
    [CustomEditor(typeof(FYManagerColor))]
    public class FYManagerColorEditor : Editor
    {
        public static FYManagerColor managerColor;
        public override void OnInspectorGUI()
        {
            // TODO:
            /* Remake DefaultInspector so that it shows scriptable object fields
             * Edit applies changes to scriptable object
             * Custom Editor Only Shows if a scriptable Object is seleted
             */
            DrawDefaultInspector();
            managerColor = (FYManagerColor)target;
            if (GUILayout.Button("Set Color Scheme"))
            {
                PaintComponents();
            }
        }
        [MenuItem("Framly/Repaint Components")]
        public static void PaintComponents()
        {
            var items = Resources.FindObjectsOfTypeAll<FYColor>();
            foreach (var item in items)
            {
                managerColor.SetItemColor(item);
            }
            SceneView.RepaintAll();
            UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
        }
    }
}