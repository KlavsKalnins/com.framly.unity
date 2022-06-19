using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framly
{
    public class ManagerColor : MonoBehaviour
    {
        public Palette palette;

        public void SetItemColor(SetColor item)
        {
            switch (item.colorType)
            {
                case ColorType.dominant:
                    item.FSetColor(palette.color.dominant);
                    break;
                case ColorType.complementary:
                    item.FSetColor(palette.color.complementary);
                    break;
                case ColorType.accent:
                    item.FSetColor(palette.color.accent);
                    break;
                case ColorType.additional:
                    item.FSetColor(palette.color.additional[item.additionalColorIndex]);
                    break;
            }
        }
        public Color GetPaletteColor(SetColor item)
        {
            switch (item.colorType)
            {
                case ColorType.dominant:
                    item.FSetColor(palette.color.dominant);
                    return palette.color.dominant;
                    break;
                case ColorType.complementary:
                    item.FSetColor(palette.color.complementary);
                    return palette.color.complementary;
                    // item.FSetColor(palette.color.complementary);
                    break;
                case ColorType.accent:
                    item.FSetColor(palette.color.accent);
                    return palette.color.accent;
                    //item.FSetColor(palette.color.accent);
                    break;
                case ColorType.additional:
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