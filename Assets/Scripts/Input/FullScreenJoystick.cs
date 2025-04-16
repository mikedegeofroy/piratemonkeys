using UnityEngine;
using UnityEngine.EventSystems;

namespace Input
{
    public class FullscreenJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private Vector2 inputVector = Vector2.zero;
        private Vector2 startPos;

        public Vector2 Direction => inputVector;

        public void OnPointerDown(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                transform as RectTransform, eventData.position, eventData.pressEventCamera, out startPos);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 currentPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                transform as RectTransform, eventData.position, eventData.pressEventCamera, out currentPos);

            Vector2 delta = currentPos - startPos;
            inputVector = Vector2.ClampMagnitude(delta / 100f, 1f);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            inputVector = Vector2.zero;
        }
    }
}