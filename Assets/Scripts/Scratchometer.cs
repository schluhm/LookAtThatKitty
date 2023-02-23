using System;
using UnityEngine;
using UnityEngine.UI;

public class Scratchometer : MonoBehaviour
{
    [SerializeField] private Transform filling;
    private Image _image;
    public float ratio;
    public Gradient gradient;

    private void Start()
    {
        _image = filling.GetComponent<Image>();
    }

    private void Update()
    {
        filling.localScale = new Vector3(ratio, 1f, 1f);
        _image.color = gradient.Evaluate(ratio);
    }
}
