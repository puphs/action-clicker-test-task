using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectExploder : MonoBehaviour
{
    private ObjectRaycaster objectRaycaster;
    private void Start()
    {
        objectRaycaster = FindObjectOfType<ObjectRaycaster>();

        objectRaycaster.ObjectRaycasted += (RaycastHit hit) =>
        {
            IExplosive explosive = hit.collider.gameObject.GetComponent<IExplosive>();
            if (explosive != null)
            {
                explosive.Explode(hit.point);
            }
        };
    }
}
