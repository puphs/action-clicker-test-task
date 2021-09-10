using System;
using UnityEngine;

public class TowerBlock : MonoBehaviour, IExplosive, IShatterable
{
    public static Action<TowerBlock> AnyShattered;
    public static Action<TowerBlock> AnyExploded;
    [SerializeField] private ExplosionSettings explosionSettings;
    [SerializeField] GameObject objectPartsParent;
    [SerializeField] float shatterOnFallVelocityThreshold = 1;

    private Rigidbody rb;
    private bool isExploded;
    private bool isShattered;

    private Collider[] tempColliders;
    private Rigidbody tempRb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        SetupPartsMaterials();
    }

    private void SetupPartsMaterials()
    {
        Material mainMaterial = GetComponent<MeshRenderer>().material;

        foreach (Transform objectPart in objectPartsParent.transform)
            objectPart.GetComponent<MeshRenderer>().material = mainMaterial;
    }

    public void Explode(Vector3 explosionCenter)
    {
        if (isExploded)
            return;
        isExploded = true;

        Shatter();
        CreateExplosionForce(explosionCenter);

        AnyExploded?.Invoke(this);
    }

    public void Shatter()
    {
        if (isShattered)
            return;
        isShattered = true;

        gameObject.SetActive(false);

        AlignPartsParent();
        objectPartsParent.gameObject.SetActive(true);

        AnyShattered?.Invoke(this);
    }

    private void AlignPartsParent()
    {
        objectPartsParent.transform.rotation = transform.rotation;
        objectPartsParent.transform.position = transform.position;
    }

    private void CreateExplosionForce(Vector3 explosionCenter)
    {
        tempColliders = Physics.OverlapSphere(explosionCenter, explosionSettings.Radius);

        foreach (Collider col in tempColliders)
        {
            tempRb = col.GetComponent<Rigidbody>();
            if (tempRb != null)
            {
                tempRb.AddExplosionForce(explosionSettings.Force, explosionCenter,
                    explosionSettings.Radius, explosionSettings.UpliftModifier);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (rb.velocity.y < 0 && rb.velocity.magnitude >= shatterOnFallVelocityThreshold)
            Shatter();
    }
}

public interface IExplosive
{
    void Explode(Vector3 explosionCenter);
}

public interface IShatterable
{
    void Shatter();
}