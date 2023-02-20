using UnityEngine;
using UnityEngine.EventSystems;

public class Util
{
    public static Vector2 GetWorldPos(PointerEventData eventData) =>
        Camera.main!.ScreenToWorldPoint(eventData.position);
}