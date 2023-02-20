using System;
using UnityEngine;
using UnityEngine.Events;

public class PromptController : MonoBehaviour
{
    private float _timer;
    [SerializeField] private float maxTimer = 5f;
    public float TimerRatio;
    public string PromptText;
    public Prompt state;
    public int score;
    public int combo = 0;
    public UnityEvent<Prompt> promptEvent = new UnityEvent<Prompt>();

    private void Update()
    {
        _timer -= Time.deltaTime;
        TimerRatio = _timer / maxTimer;
    }

    public void SetPrompt(Prompt prompt)
    {
        SetPromptState(prompt);
        SetPromptText(prompt);
        SetPromptTimer(prompt);
        promptEvent.Invoke(prompt);
    }

    private void SetPromptState(Prompt prompt)
    {
        state = prompt;
    }
    private void SetPromptText(Prompt prompt)
    {
        PromptText = prompt switch
        {
            Prompt.Feed => "Feed that kitty!",
            Prompt.Bait => "Bait that kitty!",
            Prompt.Drug => "Drug that kitty!",
            Prompt.Pet => "Pet that kitty!",
            Prompt.Checkmate => "Checkmate that kitty!",
            Prompt.Scratch => "Scratch that kitty!",
            _ => PromptText
        };
    }

    private void SetPromptTimer(Prompt prompt)
    {
        _timer = prompt switch
        {
            Prompt.Feed => 5f,
            Prompt.Bait => 5f,
            Prompt.Drug => 5f,
            Prompt.Pet => 5f,
            Prompt.Checkmate => 7f,
            Prompt.Scratch => 5f,
            _ => _timer
        };
    }

    public void ReportActionSuccess(int promptIndex)
    {
        var prompt = (Prompt)promptIndex;
        if (prompt.Equals(state))
        {
            score += (int)(100 * TimerRatio);
            combo++;
        }
        else
            combo = 0;
    }

    public void ReportActionSuccess(int promptIndex, bool success)
    {
        var prompt = (Prompt)promptIndex;
        if (prompt.Equals(state) && success)
        {
            score += (int)(100 * TimerRatio);
            combo++;
        }
        else if (prompt.Equals(state) && !success)
            combo = 0;
        _timer = prompt switch
        {
            Prompt.Checkmate => 0f,
            _ => _timer
        };
    }
    
    public enum Prompt
    {
        Feed = 0,
        Pet = 1,
        Bait = 2,
        Drug = 3,
        Checkmate = 4,
        Scratch = 5
    }
}
