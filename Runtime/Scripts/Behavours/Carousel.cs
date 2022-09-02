using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Framly
{
    public class Carousel : MonoBehaviour
    {
        public GameObject[] list;
        public IntVariable index;
        [SerializeField] bool _loop;

        void Start()
        {
            index.Changed.Register(ApplyCarousel);
        }
        private void OnDestroy()
        {
            index.Changed.Unregister(ApplyCarousel);
        }

        public void ApplyCarousel()
        {
            int getPanelsLength = list.Length;
            if (getPanelsLength < 0)
                return;

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
                if (list[i] == null)
                    return;

                list[i].SetActive(false);

                if (i == index.Value)
                {
                    list[i].SetActive(true);
                }
            }
        }
    }
}