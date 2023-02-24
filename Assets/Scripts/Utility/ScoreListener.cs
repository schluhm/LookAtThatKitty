using TMPro;
using UnityEngine;

public class ScoreListener : MonoBehaviour
{
    public bool isCombo;
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
        if(isCombo)
            _text.text = "Combo " + promptController.combo;
        else
            _text.text = "" + promptController.score;
        
    }
}
