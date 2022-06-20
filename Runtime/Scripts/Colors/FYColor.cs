using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// TODO:
/*
 * Automatically sets correct ComponentType if it finds it on gameObject
 * MeshRenderer materials from EditorInspector allow to set materials[index] color
 */

namespace Framly {
    public class FYColor : MonoBehaviour
    {
        public enum ComponentType
        {
            Image,
            TMP_Text,
            SpriteRenderer,
            Camera,
        }

        [SerializeField] ComponentType componentType;
        public Enums.ColorType colorType;
        public int additionalColorIndex;
        public void FSetColor(Color color)
        {
            var component = GetComponent(componentType.ToString());
            switch (component)
            {
                case Image:
                    component.GetComponent<Image>().color = color;
                    break;
                case Camera:
                    component.GetComponent<Camera>().backgroundColor = color;
                    break;
                case TMP_Text:
                    component.GetComponent<TMP_Text>().color = color;
                    break;
                case SpriteRenderer:
                    component.GetComponent<SpriteRenderer>().color = color;
                    break;
            }
        }
    }
}