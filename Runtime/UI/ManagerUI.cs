using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    public class ManagerUI : MonoBehaviour
    {
        public static ManagerUI Instance { get; private set; }
        public GameObject[] ui;
        public static Action<int> OnPanelChange;
        [Tooltip("Set .Panel = int; to change panel")]
        [SerializeField] int _panel;
        public int Panel
        {
            get { return _panel; }
            set { SetPanel(value); }
        }

        protected void SetPanel(int index)
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
                        _panel = index;
                        OnPanelChange?.Invoke(Panel);
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError($"error SetPanel\n{ex}");
                }
            }
        }
        public void SetPanel(PanelType panel)
        {
            Panel = (int)panel;
        }
        public PanelType GetPanel() => (PanelType)Panel;

        private void OnEnable()
        {
            Instance = this;
        }
    }
}