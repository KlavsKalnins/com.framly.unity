using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Framly {
    public class FYColor : MonoBehaviour
    {
        public enum ComponentType
        {
            Image,
            TMP_Text,
            Camera,
        }

        [SerializeField] ComponentType componentType; // Automatically sets correct component if it finds it on gameObject
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
            }
        }
    }
}