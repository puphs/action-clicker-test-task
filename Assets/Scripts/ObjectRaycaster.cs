using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private float maxDistance = 100;
    private Ray ray;
    private RaycastHit hit;
    public Action<RaycastHit> ObjectRaycasted;
    private void Start()
    {
        InputManager.MousePressed += OnMousePressed;
    }
    private void OnDestroy()
    {
        InputManager.MousePressed -= OnMousePressed;
    }

    private void OnMousePressed()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, maxDistance, layer))
        {
            ObjectRaycasted?.Invoke(hit);
        }
    }
}
