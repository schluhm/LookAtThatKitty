using TMPro;
using UnityEngine;

public class PromptTextListener : MonoBehaviour
{
    private TextMeshProUGUI _text;
    [SerializeField] private PromptController promptController;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = promptController.PromptText;
    }
}
