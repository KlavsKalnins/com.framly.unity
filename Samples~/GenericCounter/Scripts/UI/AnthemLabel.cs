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
            LanguageManager.OnLanguageChange += SetText;
            SetText();
        }
        private void Awake()
        {
            _label = GetComponent<TMPro.TMP_Text>();
        }
        private void OnDisable()
        {
            LanguageManager.OnLanguageChange -= SetText;
        }

        void SetText()
        {
            if (ManagerData.Instance == null)
                return;
            List<ManagerData.Lang> selectedDataSet;
            switch(LanguageManager.ChosenLanguageVariantId)
            {
                case 0:
                    selectedDataSet = ManagerData.Instance.data.LV;
                    break;
                case 1:
                    selectedDataSet = ManagerData.Instance.data.EN;
                    break;
                default:
                    selectedDataSet = ManagerData.Instance.data.LV;
                    break;
            }
            _label.SetText(selectedDataSet[1].Anthem + "\n" + selectedDataSet[0].Anthem);
        }
    }
}