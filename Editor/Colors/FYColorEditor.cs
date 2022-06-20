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
        public override void OnInspectorGUI()
        {
            imageColor = (FYColor)target;
            colorManager = FindObjectOfType<FYManagerColor>();
            colorManagerEditor = FindObjectOfType<FYManagerColorEditor>();
            if (imageColor.colorType == Enums.ColorType.additional)
            {
                DrawDefaultInspector();
            }
            else
            {
                serializedObject.Update();
                EditorGUI.BeginChangeCheck();
                DrawPropertiesExcluding(serializedObject, "additionalColorIndex");
                if (EditorGUI.EndChangeCheck())
                    serializedObject.ApplyModifiedProperties();
            }
            SetColor();
            serializedObject.ApplyModifiedProperties();
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