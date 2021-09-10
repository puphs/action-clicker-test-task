using System;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    public float Progress { get; private set; }
    public Action<float> ProgressUpdated;
    private int blockCount, shatteredBlockCount;

    private void Awake()
    {
        blockCount = FindObjectsOfType<TowerBlock>().Length;
    }

    public void StartProgressRecording()
    {
        shatteredBlockCount = 0;
        TowerBlock.AnyShattered += OnTowerBlockShattered;

        UpdateProgress(0);
    }
    public void StopProgressRecording()
    {
        TowerBlock.AnyShattered -= OnTowerBlockShattered;
    }

    private void OnTowerBlockShattered(TowerBlock block)
    {
        shatteredBlockCount++;
        Progress = (float)shatteredBlockCount / blockCount;

        UpdateProgress(Progress);
    }

    private void UpdateProgress(float value)
    {
        ProgressUpdated?.Invoke(value);
    }
}

