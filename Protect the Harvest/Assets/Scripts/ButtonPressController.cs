using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPressController : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
    public static bool isPressed = false;
    private Button _button;
    
    
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_button.interactable)
        {
            isPressed = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       isPressed = false;
    }
}