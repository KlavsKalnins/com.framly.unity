using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    public class FYText : MonoBehaviour, ISettableText
    {
        [Header("Required")]
        [SerializeField] FYVar _framlyVariable;
        [Header("Added from this if not provided")]
        [SerializeField] TMPro.TMP_Text _text;

        private void OnEnable()
        {
            if (_text == null)
            {
                if (TryGetComponent(out TMPro.TMP_Text component))
                    _text = component;
            }
            SetText();
        }
        public void SetText()
        {
            _text.SetText(_framlyVariable.GetStringValue());
        }
    }
}