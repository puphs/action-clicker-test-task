using System.Collections;
using System.Collections.Generic;
using RDG;
using UnityEngine;

public class ShatterVibration : MonoBehaviour
{
    [SerializeField] private long durationMilliseconds;
    [SerializeField] private byte amplitude;
    private void Start()
    {
        TowerBlock.AnyShattered += (TowerBlock block) =>
        {
            Vibration.Vibrate(durationMilliseconds, amplitude, true);
        };
    }
}
