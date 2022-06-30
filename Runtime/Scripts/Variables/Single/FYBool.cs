using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    [CreateAssetMenu(fileName = "Boolean Variable", menuName = "Framly/Variables/Boolean Variable", order = 1)]
    public class FYBool : FYVar
    {
        public bool value;

        public void SetValue(bool v)
        {
            value = v;
        }

        public void SetValue(FYBool v)
        {
            value = v.value;
        }
        public void ToggleValue()
        {
            value = !value;
        }

        public override string GetStringValue()
        {
            return value.ToString();
        }
    }
}