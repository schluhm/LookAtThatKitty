using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public bool started;
    [SerializeField] private AudioSource gameTrack; 
    [SerializeField] private PromptController promptController;
    [SerializeField] private Vector2 promptRange;
    public UnityEvent startGame;
    public UnityEvent finishedGame;
    

    public void StartGame()
    {
        startGame.Invoke();
        promptController.combo = 0;
        promptController.score = 0;
        gameTrack.time = 0;
        gameTrack.Play();
        Invoke(nameof(FinishGame), gameTrack.clip.length);
        started = true;
    }

    private void FinishGame()
    {
        started = false;
        finishedGame.Invoke();
    }

    private void Update()
    {
        if (!started) return;
        if (promptController.timerRatio <= 0)
        {
            promptController.SetPrompt((PromptController.Prompt) Random.Range(promptRange.x, promptRange.y));
        }
    }
}
