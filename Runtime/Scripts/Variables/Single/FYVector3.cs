using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    [CreateAssetMenu(fileName = "Vector3 Variable", menuName = "Framly/Variables/Vector3 Variable", order = 1)]
    public class FYVector3 : FYVar
    {
        public Vector3 value;

        public void SetValue(Vector3 v)
        {
            value = v;
        }

        public void SetValue(FYVector3 v)
        {
            value = v.value;
        }

        public void ApplyValue(Vector3 v)
        {
            value += v;
        }

        public void ApplyValue(FYVector3 v)
        {
            value += v.value;
        }

        public override string GetStringValue()
        {
            return preffix + value + suffix;
        }
    }
}