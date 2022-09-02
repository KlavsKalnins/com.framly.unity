using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Framly
{
    [CustomEditor(typeof(Carousel))]
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
                Carousel script = (Carousel)target;
                script.index.Add(1);
            }
            if (GUILayout.Button($"Dec index"))
            {
                Carousel script = (Carousel)target;
                script.index.Add(-1);
            }

        }
    }

}
