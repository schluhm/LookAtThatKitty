using TMPro;
using UnityEngine;

public class ScoreListener : MonoBehaviour
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
        _text.text = "Combo x" + promptController.combo + " " + promptController.score;
    }
}
