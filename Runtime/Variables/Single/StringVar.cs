using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    [CreateAssetMenu(fileName = "String Variable", menuName = "Framly/Variables/String Variable", order = 1)]
    public class StringVar : FVar
    {
        public string value = "";

        public override string GetStringValue()
        {
            return value.ToString();
        }
    }
}