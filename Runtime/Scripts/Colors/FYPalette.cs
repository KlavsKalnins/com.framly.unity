using UnityEngine;
using System;

namespace Framly
{
    [CreateAssetMenu(fileName = "Palette", menuName = "Framly/Palette", order = 1)]
    public class FYPalette : ScriptableObject
    {
        // TODO: Remake maybe in scriptable object in UnityAtoms struct
        [Serializable]
        public struct ColorGroup
        {
            public Color dominant;
            public Color complementary;
            public Color accent;
            public Color[] additional;
        }
        public ColorGroup color;

        public void SetPalette(FYPalette newPalette)
        {
            color = newPalette.color;
        }
    }
}