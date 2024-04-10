using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressController : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
     public static bool isPressContinue = false;
    
    #region Button Press Controller

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressContinue = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressContinue = false;
    }
    #endregion
}