using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    [CreateAssetMenu(fileName = "Integer Variable", menuName = "Framly/Variables/Integer Variable", order = 1)]
    public class IntVar : FVar
    {
        public int value;

        public void SetValue(int v)
        {
            value = v;
        }

        public void SetValue(IntVar v)
        {
            value = v.value;
        }

        public void ApplyValue(int v)
        {
            value += v;
        }

        public void ApplyValue(IntVar v)
        {
            value += v.value;
        }

        public override string GetStringValue()
        {
            return value.ToString();
        }
    }
}