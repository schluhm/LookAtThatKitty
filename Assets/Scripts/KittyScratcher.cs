using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class KittyScratcher : PromptAction
{
    public float scratchLevel;
    private float _desiredScratchLevel;
    [SerializeField] private float scratchLevelRatio;
    public UnityEvent stopScratching;
    [SerializeField] private GameObject scratchometer;
    [SerializeField] private GameObject scratchStick;
    private Scratchometer _scratchometer;

    internal new void Start()
    {
        base.Start();
        stopScratching.AddListener(SubmitScratchSuccess);
        _desiredScratchLevel = Random.Range(1f, 50f);
        _scratchometer = scratchometer.GetComponent<Scratchometer>();
    }
    
    protected override void DoAction(PromptController.Prompt currentPrompt)
    {
        scratchLevel = 0f;
        scratchometer.SetActive(currentPrompt.Equals(prompt));
        scratchStick.SetActive(currentPrompt.Equals(prompt));
        if (currentPrompt.Equals(prompt))
            _desiredScratchLevel = Random.Range(10f, 50f);
    }
    
    private void SubmitScratchSuccess()
    {
        controller.ReportActionSuccess((int)prompt, scratchLevelRatio is > 0.9f and <= 1f);
    }

    private void Update()
    {
        scratchLevelRatio = scratchLevel / _desiredScratchLevel;
        _scratchometer.ratio = scratchLevelRatio;
    }
}
