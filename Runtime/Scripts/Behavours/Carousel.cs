using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Framly
{
    public class Carousel<T> : MonoBehaviour
    {
        public IntVariable index;
        public T[] list;
        [SerializeField] protected bool _loop;

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

            if (_loop)
            {
                if (index.Value < 0)
                {
                    index.Value = getPanelsLength - 1;
                }
                else if (index.Value >= getPanelsLength)
                {
                    index.Value = 0;
                    return;
                }
            }

            if (index.Value < 0 || index.Value >= getPanelsLength)
            {
                index.Value = index.OldValue;
                return;
            }

            CarouselLogic();
        }
        public virtual void CarouselLogic()
        {
            int getPanelsLength = list.Length;

            for (int i = 0; i < getPanelsLength; i++)
            {
                if (i != index.Value)
                {
                    CarouselDisabledItemLogic(i);
                }
                else
                {
                    CarouselActiveItemLogic(i);
                }
            }
        }

        public virtual void CarouselActiveItemLogic(int i)
        {
            Debug.LogError("Please implement individual methods: 'CarouselActiveItemLogic' and 'CarouselDisabledItemLogic' \n" +
                "or implement the full CarouselLogic method by overriding it!");
        }
        public virtual void CarouselDisabledItemLogic(int i)
        {
            Debug.LogError("Please implement individual methods: 'CarouselActiveItemLogic' and 'CarouselDisabledItemLogic' \n" +
                "or implement the full CarouselLogic method by overriding it!");
        }
    }
}