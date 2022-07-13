using UnityEngine;
using UnityEngine.Events;

namespace Framly
{
    public class FYEventListener : MonoBehaviour
    {
        [SerializeField] bool _runOnEnable = false;
        [Tooltip("Event to register with.")]
        public FYEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;

        private void OnEnable()
        {
            if (!_runOnEnable)
                return;
            if (Event == null)
                return;
            Event.RegisterListener(this);
            OnEventRaised();
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