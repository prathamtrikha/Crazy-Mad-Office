using UnityEngine;
using UnityEngine.EventSystems;

public class FixedButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool Pressed;

	//When Button is pressedDown in case of MobileInput
    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }

	//When pressedButton is released in case of MobileInput
    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}
