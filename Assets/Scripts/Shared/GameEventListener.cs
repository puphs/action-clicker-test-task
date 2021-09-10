using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private UnityEvent unityEvent;

    protected virtual void OnEnable()
    {
        gameEvent.Subscribe(this);
    }

    protected virtual void OnDisable()
    {
        gameEvent.Unsubscribe(this);
    }
    public virtual void OnEventInvoked()
    {
        unityEvent?.Invoke();
    }
}
