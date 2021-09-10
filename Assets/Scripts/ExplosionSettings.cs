using UnityEngine;

[CreateAssetMenu]
public class ExplosionSettings : ScriptableObject
{
    [SerializeField] private float force = 150, radius = 1, upliftModifier = 0;
    public float Force { get => force; }
    public float Radius { get => radius; }
    public float UpliftModifier { get => upliftModifier; }
}