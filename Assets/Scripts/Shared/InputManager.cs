using System;
using UnityEngine;
using UnityEngine.EventSystems;

public enum InputMouseButton { Left, Right, Middle }
public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool ShouldHandleInput = true;
    public static Action MousePressed, MouseReleased;

    public static InputMouseButton MouseButton { get; private set; }
    public static bool isMousePressed { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (ShouldHandleInput)
        {
            isMousePressed = true;
            DetermineMouseButton(eventData);
            MousePressed?.Invoke();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (ShouldHandleInput)
        {
            isMousePressed = false;
            DetermineMouseButton(eventData);
            MouseReleased?.Invoke();
        }
    }

    private void DetermineMouseButton(PointerEventData eventData)
    {
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                MouseButton = InputMouseButton.Left;
                break;
            case PointerEventData.InputButton.Right:
                MouseButton = InputMouseButton.Right;
                break;
            case PointerEventData.InputButton.Middle:
                MouseButton = InputMouseButton.Middle;
                break;
        }
    }
    public Vector2 GetWorldPos() => Camera.main.ScreenToWorldPoint(Input.mousePosition);
}
