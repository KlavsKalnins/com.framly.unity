using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Framly
{
    public class Carousel : MonoBehaviour
    {
        public GameObject[] list;
        [SerializeField] IntVariable index;
        [SerializeField] IntEvent _onIndexChange;
        [SerializeField] bool _loop;
        void Start()
        {
            _onIndexChange.Register(ApplyCarousel);
        }
        private void OnDestroy()
        {
            _onIndexChange.Unregister(ApplyCarousel);
        }

        public void ApplyCarousel()
        {
            int getPanelsLength = list.Length;
            if (_loop)
            {
                if (index.Value < 0)
                {
                    index.Value = getPanelsLength - 1;
                }
                else if (index.Value >= getPanelsLength)
                {
                    index.Value = 0;
                }
            }

            if (index.Value < 0 || index.Value >= getPanelsLength)
            {
                index.Value = index.OldValue;
                return;
            }

            for (int i = 0; i < getPanelsLength; i++)
            {
                list[i].SetActive(false);
                try
                {
                    if (i == index.Value)
                    {
                        list[i].SetActive(true);
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Carousel Error\n{ex}");
                }
            }
        }
    }
}