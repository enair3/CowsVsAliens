using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SpriteRenderer buttonTopper;

    public void OnPointerEnter(PointerEventData buttonData)
    {
        buttonTopper.transform.position = this.transform.position;
        buttonTopper.transform.localScale = this.transform.localScale;
        buttonTopper.enabled = true;
    }

        //Detect when Cursor leaves the GameObject
   public void OnPointerExit(PointerEventData pointerEventData)
    {
        buttonTopper.enabled = false;
    }

}
