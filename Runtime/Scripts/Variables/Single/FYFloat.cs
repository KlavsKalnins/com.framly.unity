using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    [CreateAssetMenu(fileName = "Float Variable", menuName = "Framly/Variables/Float Variable", order = 1)]
    public class FYFloat : FYVar
    {
        public float value;
        [SerializeField] int decimalPlaces = 2;
        [SerializeField] string suffix;

        public void SetValue(float v)
        {
            value = v;
        }

        public void SetValue(FYFloat v)
        {
            value = v.value;
        }

        public void ApplyValue(float v)
        {
            value += v;
        }

        public void ApplyValue(FYFloat amount)
        {
            value += amount.value;
        }
        public override string GetStringValue()
        {
            return value.ToString("F" + decimalPlaces) + suffix;
        }
    }
}