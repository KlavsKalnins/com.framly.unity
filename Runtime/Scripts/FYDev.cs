using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    public class FYDev : MonoBehaviour
    {
        /* TODO: should create Input folder and create InputActions to manage better devtools
         * Create extensible solution so any variables can be added simply
         * 
         */
        FYManagerView _managerUI;
        [Header("UI cycling")]
        [SerializeField] KeyCode _panelDown = KeyCode.Q;
        [SerializeField] KeyCode _panelUp = KeyCode.W;

        private void Start()
        {
            _managerUI = FYManagerView.Instance;
        }
        private void Update()
        {
            InputsManagerUI();
        }

        private void InputsManagerUI()
        {
            if (_managerUI == null)
                return;
            if (Input.GetKeyDown(_panelDown))
                _managerUI.SetPanel(_managerUI.GetPanel() - 1);
            if (Input.GetKeyDown(_panelUp))
                _managerUI.SetPanel(_managerUI.GetPanel() + 1);
        }
    }
}