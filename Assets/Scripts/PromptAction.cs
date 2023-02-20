using UnityEngine;

public abstract class PromptAction : MonoBehaviour
{
    [SerializeField] internal PromptController controller;
    [SerializeField] internal PromptController.Prompt prompt;

    internal void Start()
    {
        RegisterSelfToController();
    }

    private void RegisterSelfToController()
    {
        controller.promptEvent.AddListener(DoAction);
    }

    protected abstract void DoAction(PromptController.Prompt currentPrompt);
}
