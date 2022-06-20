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
            _image = GetComponent<Image>();
            _image.sprite = sprite;
        }
    }
}