using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PromptAudioController : MonoBehaviour
{
    private PromptController.Prompt _currentPrompt;
    private AudioClip _currentClip; [SerializeField] private int bpm;
    [SerializeField] private int beatDist;
    [SerializeField] private int beatCounter;
    private float _entrypoint;

    [SerializeField] private List<AudioClip> feedClips;
    [SerializeField] private List<AudioClip> petClips;
    [SerializeField] private List<AudioClip> baitClips;
    [SerializeField] private List<AudioClip> drugClips;
    [SerializeField] private List<AudioClip> checkmateClips;
    [SerializeField] private List<AudioClip> scratchClips;
    [SerializeField] private List<AudioClip> danceClips;
    [SerializeField] private List<AudioClip> lookClips;

    private float _startTime;
    private float _currentTime;
    private AudioSource _audioSource;
    private bool _started;
    private bool _songQueued;
    private bool _freshPrompt;

    private void Start()
    {
        _entrypoint = 60f / bpm * 4;
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartAudioPrompts()
    {
        _startTime = Time.time;
        _currentTime = 0;
        _started = true;
    }

    public void FinishAudioPrompts()
    {
        _started = false;
    }

    private void Update()
    {
        if (!_started) return;
        if (_currentTime > _entrypoint * (beatDist - 1) && !_songQueued && _freshPrompt)
        {
            _freshPrompt = false;
            _songQueued = true;
            beatCounter += beatDist;
            _audioSource.Stop();
            _audioSource.clip = _currentClip;
            _audioSource.PlayScheduled(_startTime + beatCounter * _entrypoint);
            _currentTime += Time.deltaTime;
            return;
        }
        else if (_currentTime >= _entrypoint * beatDist)
        {
            _currentTime = 0f;
            _songQueued = false;
            return;
        }

        _currentTime += Time.deltaTime;
    }

    public void SetCurrentPrompt(PromptController.Prompt prompt)
    {
        _songQueued = false;
        _freshPrompt = true;
        _currentPrompt = prompt;
        SetCurrentClip();
    }

    private void SetCurrentClip()
    {
        switch (_currentPrompt)
        {
            case PromptController.Prompt.Feed:
                _currentClip = feedClips[Random.Range(0, feedClips.Count)];
                break;
            case PromptController.Prompt.Pet:
                _currentClip = petClips[Random.Range(0, petClips.Count)];
                break;
            case PromptController.Prompt.Bait:
                _currentClip = baitClips[Random.Range(0, baitClips.Count)];
                break;
            case PromptController.Prompt.Drug:
                _currentClip = drugClips[Random.Range(0, drugClips.Count)];
                break;
            case PromptController.Prompt.Checkmate:
                _currentClip = checkmateClips[Random.Range(0, checkmateClips.Count)];
                break;
            case PromptController.Prompt.Scratch:
                _currentClip = scratchClips[Random.Range(0, scratchClips.Count)];
                break;
            case PromptController.Prompt.Dance:
                _currentClip = danceClips[Random.Range(0, danceClips.Count)];
                break;
            default:
                break;
        }
    }
}