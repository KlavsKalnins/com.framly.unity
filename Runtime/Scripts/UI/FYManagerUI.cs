using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    public class FYManagerUI : MonoBehaviour
    {
        public static FYManagerUI Instance { get; private set; }
        public GameObject[] ui;
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
            int getPanelsLength = ui.Length;
            if (index < 0 || index >= getPanelsLength)
                return;

            for (int i = 0; i < getPanelsLength; i++)
            {
                ui[i].SetActive(false);
                try
                {
                    if (i == index)
                    {
                        ui[i].SetActive(true);
                        _panelIndex.value = index;
                        // onPanelChange.Raise();
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