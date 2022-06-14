using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Framly
{
    [CreateAssetMenu(fileName = "Palette Variant", menuName = "Framly/PaletteColors", order = 1)]
    public class Palette : ScriptableObject
    {

        [Serializable]
        public struct ColorGroup
        {
            public Color dominant;
            public Color complementary;
            public Color accent;
            public Color[] additional;
        }
        public ColorGroup color;
    }
}