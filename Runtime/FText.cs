using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    public class FText : MonoBehaviour, ISettableText
    {
        [SerializeField] TMPro.TMP_Text _text;
        [SerializeField] FVar _framlyVariable;

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