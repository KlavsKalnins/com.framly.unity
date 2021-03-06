using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    public static class FYDataSet
    {
        public static T CreateDataSet<T>(TextAsset dataset)
        {
            return JsonUtility.FromJson<T>(dataset.text);
        }
    }
}