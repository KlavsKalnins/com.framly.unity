using UnityEngine;

namespace Framly
{
    public class FYManagerTheme : MonoBehaviour
    {
        public static FYManagerTheme Instance { get; private set; }
        [SerializeField] FYPalette[] paletteList;
        public FYPalette palette;

        private void OnEnable()
        {
            Instance = this;
        }

        public void SetPaletteFromList(int paletteIndex)
        {
            SetPalette(paletteList[paletteIndex]);
        }
        public void SetPalette(FYPalette palette)
        {
            this.palette = palette;
            Repaint();
        }

        public void Repaint()
        {
            var items = Resources.FindObjectsOfTypeAll<FYColor>();
            foreach (var item in items)
            {
                SetItemColor(item);
            }
        }

        public void SetItemColor(FYColor item)
        {
            switch (item.colorType)
            {
                case Enums.ColorType.dominant:
                    item.FSetColor(palette.color.dominant);
                    break;
                case Enums.ColorType.complementary:
                    item.FSetColor(palette.color.complementary);
                    break;
                case Enums.ColorType.accent:
                    item.FSetColor(palette.color.accent);
                    break;
                case Enums.ColorType.additional:
                    item.FSetColor(palette.color.additional[item.additionalColorIndex]);
                    break;
            }
        }
        public Color GetPaletteColor(FYColor item)
        {

            switch (item.colorType)
            {
                case Enums.ColorType.dominant:
                    item.FSetColor(palette.color.dominant);
                    return palette.color.dominant;
                case Enums.ColorType.complementary:
                    item.FSetColor(palette.color.complementary);
                    return palette.color.complementary;
                case Enums.ColorType.accent:
                    item.FSetColor(palette.color.accent);
                    return palette.color.accent;
                case Enums.ColorType.additional:
                    item.FSetColor(palette.color.additional[item.additionalColorIndex]);
                    return palette.color.additional[item.additionalColorIndex];
                default:
                    return new Color(0, 0, 0, 0);
            }
        }
    }
}