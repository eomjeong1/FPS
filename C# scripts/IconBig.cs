using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IconBig : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform buttonScale;
    Vector3 defaultScale;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }
}
