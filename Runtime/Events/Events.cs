using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    [SerializeField] bool _triggerAtStart;
    public UnityEvent events = new UnityEvent();

    private void OnEnable()
    {
        if (!_triggerAtStart)
            return;
        EventInvoke();
    }

    public void EventInvoke()
    {
        events?.Invoke();
    }
}