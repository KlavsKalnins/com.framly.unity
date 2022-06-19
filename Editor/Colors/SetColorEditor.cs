using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Framly
{
    [CustomEditor(typeof(SetColor))]
    [CanEditMultipleObjects]
    public class SetColorEditor : Editor
    {
        ManagerColor colorManager;
        ManagerColorEditor colorManagerEditor;
        SetColor imageColor;
        public override void OnInspectorGUI()
        {
            imageColor = (SetColor)target;
            colorManager = FindObjectOfType<ManagerColor>();
            colorManagerEditor = FindObjectOfType<ManagerColorEditor>();
            if (imageColor.colorType == ColorType.additional)
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