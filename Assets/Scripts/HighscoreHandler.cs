using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Utility;

public class HighscoreHandler : MonoBehaviour
{
    public int score;
    [SerializeField] private TextMeshProUGUI highscores;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextAsset dbDomain;
    [SerializeField] private TextAsset token;
    [SerializeField] private PromptController promptController;
    
    public void UpdateHighScores()
    {
        highscores.text = "Loading ...";
        StartCoroutine(HighScore.RequestTop10(res =>
        {
            highscores.text = res.could_load
                ? string.Join("\n", res.highscores.Select((hs) => hs.name + " - " + hs.value))
                : "Error loading high scores.";
        }, dbDomain.text));
    }

    public void PostScore()
    {
        score = promptController.score;
        if (playerName.text.Trim() == "") return;
        StartCoroutine(HighScore.UploadHighScore(new HighScore.Entry
        {
            name = playerName.text,
            value = score
        } ,dbDomain.text , token.text));
    }
}
