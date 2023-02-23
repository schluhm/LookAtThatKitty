using System;
using UnityEngine;

public class TimerListener : MonoBehaviour
{
    [SerializeField] private Vector2 startEndHandleX;
    [SerializeField] private Vector2 startEndFillingScale;
    [SerializeField] private Transform filling;
    [SerializeField] private Transform handle;
    [SerializeField] private PromptController controller;
    
    private void Update()
    {
        filling.localScale = new Vector3((1f - controller.timerRatio) * (startEndFillingScale.y - startEndFillingScale.x) + startEndFillingScale.x,
            1f, 1f);
        handle.localPosition =
            new Vector3((1f - controller.timerRatio) * (startEndHandleX.y - startEndHandleX.x) + startEndHandleX.x, handle.localPosition.y, handle.localPosition.z);
    }
}