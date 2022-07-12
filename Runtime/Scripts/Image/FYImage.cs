using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Framly
{
    public class FYImage : MonoBehaviour
    {
        private Image _image;
        public Enums.ImageComponent imageComponent;

        public void SetSprite(Sprite sprite)
        {
            if (TryGetComponent(out Image component))
            {
                _image = component;
                _image.sprite = sprite;
            }

        }
    }
}