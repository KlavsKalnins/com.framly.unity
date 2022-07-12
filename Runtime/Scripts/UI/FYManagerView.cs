using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    public class FYManagerView : MonoBehaviour
    {
        public static FYManagerView Instance { get; private set; }
        public GameObject[] views;
        public static Action<int> OnPanelChange;
        [Tooltip("Set .Panel = int; to change panel")]
        [SerializeField] FYInt _panelIndex;
        [SerializeField] FYGameEvent onPanelChange;

        public void SetPanel()
        {
            SetPanel(_panelIndex.value);
        }

        public void SetPanel(int index)
        {
            int getPanelsLength = views.Length;
            if (index < 0 || index >= getPanelsLength)
                return;

            for (int i = 0; i < getPanelsLength; i++)
            {
                views[i].SetActive(false);
                try
                {
                    if (i == index)
                    {
                        views[i].SetActive(true);
                        _panelIndex.value = index;
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError($"error SetPanel\n{ex}");
                }
            }
        }
        public void SetPanel(Enums.PanelType panel)
        {
            SetPanel((int)panel);
        }
        public Enums.PanelType GetPanel() => (Enums.PanelType)_panelIndex.value;

        private void OnEnable()
        {
            Instance = this;
        }
    }
}