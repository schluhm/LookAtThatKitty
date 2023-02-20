using System;
using UnityEngine;

public class CootsController : MonoBehaviour
{
    [SerializeField] private PromptController controller;
    [SerializeField] private GameObject CootsDefault;
    [SerializeField] private GameObject ChasingCoots;
    [SerializeField] private GameObject HungryCoots;
    [SerializeField] private GameObject ChessCoots;

    private void Start()
    {
        controller.promptEvent.AddListener(ChangeCoots);
    }

    private void ChangeCoots(PromptController.Prompt prompt)
    {
        switch (prompt)
        {
            case PromptController.Prompt.Bait:
                ChasingCoots.SetActive(true);
                CootsDefault.SetActive(false);
                HungryCoots.SetActive(false);
                ChessCoots.SetActive(false);
                break;
            case PromptController.Prompt.Drug:
                ChasingCoots.SetActive(false);
                CootsDefault.SetActive(false);
                HungryCoots.SetActive(true);
                ChessCoots.SetActive(false);
                break;
            case PromptController.Prompt.Checkmate:
                ChasingCoots.SetActive(false);
                CootsDefault.SetActive(false);
                HungryCoots.SetActive(false);
                ChessCoots.SetActive(true);
                break;
            case PromptController.Prompt.Feed:
            case PromptController.Prompt.Pet:
            case PromptController.Prompt.Scratch:
            default:
                ChasingCoots.SetActive(false);
                CootsDefault.SetActive(true);
                HungryCoots.SetActive(false);
                ChessCoots.SetActive(false);
                break;
        }
    }
}