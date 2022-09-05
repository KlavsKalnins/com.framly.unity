using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Framly
{
    [CustomEditor(typeof(CarouselGameObject))]
    public class CarouselEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (!Application.isPlaying)
            {
                GUI.enabled = false;
            }
            if (GUILayout.Button($"Add index"))
            {
                CarouselGameObject script = (CarouselGameObject)target;
                script.index.Add(1);
            }
            if (GUILayout.Button($"Dec index"))
            {
                CarouselGameObject script = (CarouselGameObject)target;
                script.index.Add(-1);
            }

        }
    }

}
