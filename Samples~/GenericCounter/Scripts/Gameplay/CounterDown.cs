using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framly;

public class CounterDown : MonoBehaviour
{
    [SerializeField] FloatVar counterTimer;
    [SerializeField] GameEvent _events;
    [SerializeField] GameEvent _onCounterFinished;
    private void OnEnable()
    {

    }
    void Update()
    {
        counterTimer.value -= Time.deltaTime;
        _events.Raise();
        if (counterTimer.value <= 0)
        {
            _onCounterFinished.Raise();
            return;
        }
    }
}
