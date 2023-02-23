using System;
using UnityEngine;

public class CootsController : MonoBehaviour
{
    [SerializeField] private PromptController controller;
    [SerializeField] private GameObject cootsDefault;
    [SerializeField] private GameObject chasingCoots;
    [SerializeField] private GameObject hungryCoots;
    [SerializeField] private GameObject chessCoots;
    [SerializeField] private GameObject scratchCoots;
    [SerializeField] private GameObject danceCoots;

    private void Start()
    {
        controller.promptEvent.AddListener(ChangeCoots);
    }

    private void ChangeCoots(PromptController.Prompt prompt)
    {
        switch (prompt)
        {
            case PromptController.Prompt.Bait:
                chasingCoots.SetActive(true);
                cootsDefault.SetActive(false);
                hungryCoots.SetActive(false);
                chessCoots.SetActive(false);
                scratchCoots.SetActive(false);
                danceCoots.SetActive(false);
                break;
            case PromptController.Prompt.Drug:
                chasingCoots.SetActive(false);
                cootsDefault.SetActive(false);
                hungryCoots.SetActive(true);
                chessCoots.SetActive(false);
                scratchCoots.SetActive(false);
                danceCoots.SetActive(false);
                break;
            case PromptController.Prompt.Checkmate:
                chasingCoots.SetActive(false);
                cootsDefault.SetActive(false);
                hungryCoots.SetActive(false);
                chessCoots.SetActive(true);
                scratchCoots.SetActive(false);
                danceCoots.SetActive(false);
                break;
            case PromptController.Prompt.Scratch:
                chasingCoots.SetActive(false);
                cootsDefault.SetActive(false);
                hungryCoots.SetActive(false);
                chessCoots.SetActive(false);
                scratchCoots.SetActive(true);
                danceCoots.SetActive(false);
                break;
            case PromptController.Prompt.Dance:
                chasingCoots.SetActive(false);
                cootsDefault.SetActive(false);
                hungryCoots.SetActive(false);
                chessCoots.SetActive(false);
                scratchCoots.SetActive(false);
                danceCoots.SetActive(true);
                break;
            case PromptController.Prompt.Feed:
            case PromptController.Prompt.Pet:
            default:
                chasingCoots.SetActive(false);
                cootsDefault.SetActive(true);
                hungryCoots.SetActive(false);
                chessCoots.SetActive(false);
                scratchCoots.SetActive(false);
                danceCoots.SetActive(false);
                break;
        }
    }
}