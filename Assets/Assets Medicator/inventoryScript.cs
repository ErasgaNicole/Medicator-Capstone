using UnityEngine;
using UnityEngine.EventSystems;

public class inventoryScript : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount != 7)
        {
            GameObject droppedObject = eventData.pointerDrag;
            draggableItem draggable = droppedObject.GetComponent<draggableItem>();
            draggable.setParentAferDrag = transform;
        }
    }
}
