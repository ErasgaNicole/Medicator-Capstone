using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class draggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler , IEndDragHandler
{
    private Image imageObject;
    [HideInInspector] public Transform setParentAferDrag;
    public void Start()
    {
        Time.timeScale = 0;
        imageObject = GetComponent<Image>();

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        imageObject.raycastTarget = false;
        setParentAferDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    { 
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0.0f;
        transform.position = mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        imageObject.raycastTarget = true;
        transform.SetParent(setParentAferDrag);        
    }
}
