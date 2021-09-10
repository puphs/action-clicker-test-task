using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour, IProgressBar
{
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private Image progressImage;

    public void UpdateProgress(float value)
    {
        value = Mathf.Clamp01(value);

        UpdateProgressImage(value);
        UpdateProgressText(value);
    }

    private void UpdateProgressImage(float progress)
    {
        progressImage.rectTransform.anchorMax = new Vector2(progress, 1);
    }
    private void UpdateProgressText(float progress)
    {
        if (progressText == null)
            return;

        progressText.text = progress.ToString("P0");
    }
}

public interface IProgressBar
{
    void UpdateProgress(float value);
}