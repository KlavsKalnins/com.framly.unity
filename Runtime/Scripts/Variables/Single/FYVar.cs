using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    // TODO: maybe can do generic type FYVar<T>
    public abstract class FYVar : ScriptableObject
    {
        // public T value;
        // but would be difficult to base class generic as i would have to set the type <int, stirng, etc.>
        public string preffix;
        public string suffix;
        public abstract string GetStringValue();
    }
}