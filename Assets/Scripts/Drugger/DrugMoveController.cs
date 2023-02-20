using System;
using UnityEngine;

public class DrugMoveController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 mousePos = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        _rigidbody2D.MovePosition(mousePos);
    }
}
