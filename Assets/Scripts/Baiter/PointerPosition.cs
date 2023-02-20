using UnityEngine;

public class PointerPosition : MonoBehaviour
{
    public static Vector2 PointerPos;

    // Update is called once per frame
    void Update()
    {
        PointerPos = transform.position;
    }
}
