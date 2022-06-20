using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    public class FYText : MonoBehaviour, ISettableText
    {
        [SerializeField] TMPro.TMP_Text _text;
        [SerializeField] FYVar _framlyVariable;

        private void OnEnable()
        {
            SetText();
        }
        public void SetText()
        {
            _text.SetText(_framlyVariable.GetStringValue());
        }
    }
}