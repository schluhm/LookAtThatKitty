using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public bool started;
    [SerializeField] private AudioSource gameTrack; 
    [SerializeField] private PromptController promptController;
    public UnityEvent startGame;
    public UnityEvent finishedGame;

    public void StartGame()
    {
        startGame.Invoke();
        promptController.combo = 0;
        promptController.score = 0;
        gameTrack.time = 0;
        gameTrack.Play();
        started = true;
    }

    private void Update()
    {
        if (!started) return;
        if (!gameTrack.isPlaying)
        {
            started = false;
            finishedGame.Invoke();
        }
        if (promptController.TimerRatio <= 0)
        {
            promptController.SetPrompt((PromptController.Prompt) Random.Range(4,5));
        }
    }
}
