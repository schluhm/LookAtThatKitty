using UnityEngine;

public class KittyDancer : PromptAction
{
    [SerializeField] private GameObject dancer;
    [SerializeField] private GameObject spinningWheel;
    protected override void DoAction(PromptController.Prompt currentPrompt)
    {
        if (currentPrompt.Equals(prompt))
        {
            dancer.SetActive(true);
            spinningWheel.SetActive(true);
        }
        else
        {
            dancer.SetActive(false);
            spinningWheel.SetActive(false);
        }
    }
}
