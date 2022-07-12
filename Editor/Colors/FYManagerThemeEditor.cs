using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Framly
{
    [CustomEditor(typeof(FYManagerTheme))]
    public class FYManagerColorEditor : Editor
    {
        public static FYManagerTheme managerColor;
        public override void OnInspectorGUI()
        {
            // TODO:
            /* Remake DefaultInspector so that it shows scriptable object fields
             * Edit applies changes to scriptable object
             * Custom Editor Only Shows if a scriptable Object is seleted
             */
            DrawDefaultInspector();
            managerColor = (FYManagerTheme)target;
            if (GUILayout.Button("Set Color Scheme"))
            {
                PaintComponents();
            }
        }
        [MenuItem("Framly/Repaint Components")]
        public static void PaintComponents()
        {
            managerColor.Repaint();
            SceneView.RepaintAll();
            UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
        }
    }
}