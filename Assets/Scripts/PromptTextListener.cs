using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PromptTextListener : MonoBehaviour
{
    private Image _text;
    [SerializeField] private List<Sprite> promptText;
    [SerializeField] private PromptController promptController;
    private void Start()
    {
        _text = GetComponent<Image>();
    }

    private void Update()
    {
        _text.sprite = promptText[(int)promptController.state];
    }
}
