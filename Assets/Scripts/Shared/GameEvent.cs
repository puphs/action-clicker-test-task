using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Invoke()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventInvoked();
    }

    public void Subscribe(GameEventListener listener)
    {
        listeners.Add(listener);
    }
    public void Unsubscribe(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
