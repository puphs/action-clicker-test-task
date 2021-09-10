using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFlow : MonoBehaviour
{
    [SerializeField] private GameEvent levelStartedEvent, levelCompletedEvent;
    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private float progressToCompleteLevel;

    private void Start()
    {
        InputManager.ShouldHandleInput = false;

        levelProgress.ProgressUpdated += (float value) =>
        {
            if (value >= progressToCompleteLevel)
                CompleteLevel();
        };

        StartLevel();
    }

    private void StartLevel()
    {
        InputManager.ShouldHandleInput = true;
        levelStartedEvent?.Invoke();
    }

    private void CompleteLevel()
    {
        InputManager.ShouldHandleInput = false;
        levelCompletedEvent?.Invoke();
    }
}
