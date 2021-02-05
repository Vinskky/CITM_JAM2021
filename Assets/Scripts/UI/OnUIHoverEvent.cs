using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnUIHoverEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private Image cardShowImage;

    void Start()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cardShowImage.sprite = GetComponent<Image>().sprite;
        cardShowImage.enabled = true;

    }

    
    public void OnPointerExit(PointerEventData eventData)
    {

        cardShowImage.enabled = false;
        // transform.localScale = cachedScale;

    }
}
