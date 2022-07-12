using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    public class AnthemLabel : MonoBehaviour
    {
        [SerializeField] TMPro.TMP_Text _label;
        private void OnEnable()
        {
            SetText();
        }
        private void Awake()
        {
            if (TryGetComponent(out TMPro.TMP_Text component))
            {
                _label = component;
            }
        }
        private void OnDisable()
        {
        }

        void SetText()
        {
            if (ManagerData.Instance == null)
                return;
            List<ManagerData.Lang> selectedDataSet;
        }
    }
}