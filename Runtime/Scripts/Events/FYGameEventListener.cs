﻿using UnityEngine;
using UnityEngine.Events;

namespace Framly
{
    public class FYGameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public FYGameEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;

        private void OnEnable()
        {
            if (Event == null)
                return;
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (Event == null)
                return;
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}