using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scratchometer : MonoBehaviour
{
    [SerializeField] private Vector2 startEndHandleX;
    [SerializeField] private Vector2 startEndFillingScale;
    [SerializeField] private Transform filling;
    [SerializeField] private Transform handle;
    public List<Image> fillingImages;
    public float ratio;
    public Gradient gradient;
    
    private void Update()
    {
        filling.localScale = new Vector3(ratio * (startEndFillingScale.y - startEndFillingScale.x) + startEndFillingScale.x,
            1f, 1f);
        handle.localPosition =
            new Vector3(ratio * (startEndHandleX.y - startEndHandleX.x) + startEndHandleX.x, handle.localPosition.y, handle.localPosition.z);
        foreach (var image in fillingImages)
        {
            image.color = gradient.Evaluate(ratio);
        }
    }
}
