using System;
using Chess;
using UnityEngine;

public class KittyMater : PromptAction
{
    [SerializeField] private Chessboard chessboard;
    [SerializeField] private GameObject boardHolder;
    protected override void DoAction(PromptController.Prompt currentPrompt)
    {
        boardHolder.SetActive(currentPrompt.Equals(prompt));
        if (currentPrompt.Equals(prompt))
        {
            chessboard.SetupRiddle();
        }
    }
}
