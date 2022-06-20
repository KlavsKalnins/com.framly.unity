using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Framly
{
    public class FYFloatRef : ScriptableObject
    {
        
        [Serializable]
        public class FloatReference
        {
            public bool UseConstant = true;
            public float ConstantValue;
            public FYFloat Variable;

            public FloatReference()
            { }

            public FloatReference(float value)
            {
                UseConstant = true;
                ConstantValue = value;
            }

            public float Value
            {
                get { return UseConstant ? ConstantValue : Variable.value; }
            }

            public static implicit operator float(FloatReference reference)
            {
                return reference.Value;
            }
        }
        
    }

}