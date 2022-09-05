using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framly;

public class CarouselGameObject : Carousel<GameObject>
{


    // Both implementations are considered valid
    // #1
    /*
    public override void CarouselLogic()
    {
        int getPanelsLength = list.Length;
        base.CarouselLogic();

        for (int i = 0; i < getPanelsLength; i++)
        {
            list[i].SetActive(false);

            if (i == index.Value)
            {
                list[i].SetActive(true);
            }
        }
    }
    */

    // #2

    public override void CarouselActiveItemLogic(int i)
    {
        list[i].SetActive(true);
    }
    public override void CarouselDisabledItemLogic(int i)
    {
        list[i].SetActive(false);
    }
}