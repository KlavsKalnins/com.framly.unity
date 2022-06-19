using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    public abstract class FVar : ScriptableObject
    {
        public abstract string GetStringValue();
    }
}