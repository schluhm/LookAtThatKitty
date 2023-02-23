using System;
using UnityEngine;

public class ScratchReceiver : MonoBehaviour
{
    private Vector2 _mousePosition;
    [SerializeField] private KittyScratcher kittyScratcher;

    public void OnMouseDown()
    {
        _mousePosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        var newMousePosTemp = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        var mouseDelta = Mathf.Abs(Vector2.Distance(_mousePosition, (Vector2)newMousePosTemp));
        _mousePosition = newMousePosTemp;
        kittyScratcher.scratchLevel += mouseDelta;
    }

    public void OnMouseUp()
    {
        kittyScratcher.stopScratching.Invoke();
    }


    private void FixedUpdate()
    {
        _mousePosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
    }
}