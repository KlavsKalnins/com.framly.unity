using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Framly
{
    [CustomEditor(typeof(ManagerColor))]
    public class ManagerColorEditor : Editor
    {
        public static ManagerColor managerColor;
        public override void OnInspectorGUI()
        {
            // TODO:
            /* Remake DefaultInspector so that it shows scriptable object fields
             * Edit applies changes to scriptable object
             * Custom Editor Only Shows if a scriptable Object is seleted
             */
            DrawDefaultInspector();
            managerColor = (ManagerColor)target;
            if (GUILayout.Button("Set Color Scheme"))
            {
                PaintComponents();
            }
        }
        [MenuItem("Framly/Repaint Components")]
        public static void PaintComponents()
        {
            var items = Resources.FindObjectsOfTypeAll<SetColor>();
            foreach (var item in items)
            {
                SetItemColor(item);
            }
            SceneView.RepaintAll();
            UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
        }
        
        private static void SetItemColor(SetColor item)
        {
            // TODO: IJob?
            managerColor = FindObjectOfType<ManagerColor>();
            switch (item.colorType)
            {
                case ColorType.dominant:
                    item.FSetColor(managerColor.palette.color.dominant);
                    break;
                case ColorType.complementary:
                    item.FSetColor(managerColor.palette.color.complementary);
                    break;
                case ColorType.accent:
                    item.FSetColor(managerColor.palette.color.accent);
                    break;
                case ColorType.additional:
                    item.FSetColor(managerColor.palette.color.additional[item.additionalColorIndex]);
                    break;
            }
        }
    }
}