using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick :
    MonoBehaviour,
    IDragHandler,
    IPointerUpHandler,
    IPointerDownHandler
{
    public RectTransform background;
    public RectTransform handle;

    private Vector2 inputVector;

    public float Horizontal
    {
        get { return inputVector.x; }
    }

    public float Vertical
    {
        get { return inputVector.y; }
    }

    public Vector2 Direction
    {
        get { return inputVector; }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background,
            eventData.position,
            eventData.pressEventCamera,
            out position))
        {
            position.x =
                position.x / background.sizeDelta.x;

            position.y =
                position.y / background.sizeDelta.y;

            inputVector =
                new Vector2(
                    position.x * 2,
                    position.y * 2
                );

            inputVector =
                inputVector.magnitude > 1
                ? inputVector.normalized
                : inputVector;

            handle.anchoredPosition =
                new Vector2(
                    inputVector.x *
                    (background.sizeDelta.x / 3),

                    inputVector.y *
                    (background.sizeDelta.y / 3)
                );
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;

        handle.anchoredPosition = Vector2.zero;
    }
}
