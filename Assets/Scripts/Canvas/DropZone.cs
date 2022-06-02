using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IBeginDragHandler
{
    public Transform toParent;
    [SerializeField] int childFilled = 0;
    public bool isFilled;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.gameObject.name);
    }

    public void OnDrop(PointerEventData eventData)
    {
        isFilled = toParent.transform.childCount >= childFilled;

        if (eventData != null && !isFilled)
        {
            DragAndDrop d = eventData.pointerDrag.GetComponent<DragAndDrop>();
            eventData.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = true;
            Instantiate(d, toParent);
            Destroy(eventData.pointerDrag.gameObject);
        }
    }

}
