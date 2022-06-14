using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Framly
{
    [CustomEditor(typeof(SetColor))]
    public class SetColorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var imageColor = (SetColor)target;
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
        }
    }
}