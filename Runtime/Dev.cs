using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    public class Dev : MonoBehaviour
    {
        /* TODO: should create Input folder and create InputActions to manage better devtools
         * Create extensible solution so any variables can be added simply
         * 
         */
        ManagerUI _managerUI;
        [Header("UI cycling")]
        [SerializeField] KeyCode _panelDown = KeyCode.Q;
        [SerializeField] KeyCode _panelUp = KeyCode.W;

        private void Start()
        {
            _managerUI = ManagerUI.Instance;
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
                _managerUI.Panel--;
            if (Input.GetKeyDown(_panelUp))
                _managerUI.Panel++;           
        }
    }
}