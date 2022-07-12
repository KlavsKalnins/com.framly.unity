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
        FYManagerTheme colorManager;
        FYColor imageColor;

        public override void OnInspectorGUI()
        {
            imageColor = (FYColor)target;
            colorManager = FindObjectOfType<FYManagerTheme>();
            if (colorManager == null)
            {
                EditorGUILayout.LabelField("FYManagerTheme in hierarchy not found!");
                return;
            }

            if (colorManager.palette == null)
                return;

            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            DrawPropertiesExcluding(serializedObject, "additionalColorIndex");
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();

            if (colorManager.palette.color.additional.Length - 1 < 0)
            {
                EditorGUILayout.LabelField("No additional color found in FYManagerTheme!");
                return;
            }
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