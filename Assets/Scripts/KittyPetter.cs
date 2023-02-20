using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyPetter : PromptAction
{
    [SerializeField] private Transform hand;
    
    protected override void DoAction(PromptController.Prompt currentPrompt)
    {
        hand.gameObject.SetActive(currentPrompt.Equals(prompt));
    }
}
