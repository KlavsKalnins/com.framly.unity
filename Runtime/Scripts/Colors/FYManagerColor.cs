using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    public class FYManagerColor : MonoBehaviour
    {
        public FYPalette palette;

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
                    break;
                case Enums.ColorType.complementary:
                    item.FSetColor(palette.color.complementary);
                    return palette.color.complementary;
                    // item.FSetColor(palette.color.complementary);
                    break;
                case Enums.ColorType.accent:
                    item.FSetColor(palette.color.accent);
                    return palette.color.accent;
                    //item.FSetColor(palette.color.accent);
                    break;
                case Enums.ColorType.additional:
                    try
                    {
                        item.FSetColor(palette.color.additional[item.additionalColorIndex]);
                        return palette.color.additional[item.additionalColorIndex];
                    } catch (Exception ex)
                    {
                        Debug.LogError($"loll: \n {ex}");
                    }
                    return palette.color.additional[0];
                    //item.FSetColor(palette.color.additional[item.additionalColorIndex]);
                    break;
                    default:
                    return new Color(0, 0, 0, 0);
                    break;
            }
        }
    }
}