using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private GameObject levelCompletePopup;
    private void Awake()
    {
        levelProgress.ProgressUpdated += (float value) =>
        {
            progressBar.UpdateProgress(value);
        };
    }

    public void OnLevelComplete()
    {
        levelCompletePopup.SetActive(true);
    }
}
