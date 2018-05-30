using UnityEngine;
using UnityEngine.EventSystems;

namespace Lesson2.UI.Drag
{
    public class DragAndDropTrigger : EventTrigger
    {
        public override void OnDrag(PointerEventData eventData)
        {
            eventData.Use();
            gameObject.transform.position += new Vector3(eventData.delta.x, eventData.delta.y);
            base.OnDrag(eventData);
        }

    }
}