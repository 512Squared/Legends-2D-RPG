using UnityEngine.EventSystems;
using UnityEngine;

public class MouseOffObjectClicks : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    bool MouseOnObject = false;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        MouseOnObject = true;

    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        MouseOnObject = false;
    }


    void Update()
    {

        if ((Input.GetMouseButtonDown(0)) && (!MouseOnObject))
        {
            this.gameObject.SetActive(false);
        }

    }

}
