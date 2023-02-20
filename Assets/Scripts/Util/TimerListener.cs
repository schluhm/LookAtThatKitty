using System;
using UnityEngine;

public class TimerListener : MonoBehaviour
{
    [SerializeField] private Transform filling;
    [SerializeField] private PromptController controller;

    private void Update()
    {
        filling.localScale = new Vector3(controller.TimerRatio, 1f, 1f);
    }
}
