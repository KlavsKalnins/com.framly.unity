using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Framly
{
    public class ManagerImage : MonoBehaviour
    {
        public static ManagerImage Instance { get; private set; }
        [Serializable]
        public struct ImageComponent
        {
            public string name;
            public Sprite sprite;
        }
        public ImageComponent[] imageComponets;
        private void OnEnable()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple Component found | Singleton" + this);
                return;
            }
            Instance = this;
        }
    }
}