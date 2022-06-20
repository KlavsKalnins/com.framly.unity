using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Framly
{
    [CustomEditor(typeof(FYColor))]
    [CanEditMultipleObjects]
    public class FYColorEditor : Editor
    {
        FYManagerColor colorManager;
        FYManagerColorEditor colorManagerEditor;
        FYColor imageColor;
        static int scale = 0;
        public override void OnInspectorGUI()
        {
            imageColor = (FYColor)target;
            colorManager = FindObjectOfType<FYManagerColor>();
            colorManagerEditor = FindObjectOfType<FYManagerColorEditor>();

            if (colorManager.palette == null)
                return;

            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            DrawPropertiesExcluding(serializedObject, "additionalColorIndex");
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();

            if (imageColor.colorType == Enums.ColorType.additional)
            {
                imageColor.additionalColorIndex = EditorGUILayout.IntSlider(imageColor.additionalColorIndex, 0, colorManager.palette.color.additional.Length - 1);
            }
            SetColor();
            serializedObject.ApplyModifiedProperties();
            SceneView.RepaintAll();
        }

        private void SetColor()
        {
            if (colorManager == null)
                return;
            Color color = colorManager.GetPaletteColor(imageColor);
            Rect r = new Rect(0, 0, 20, 20);
            EditorGUI.DrawRect(r, color);
        }
    }
}