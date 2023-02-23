using UnityEngine;
using UnityEngine.Events;

public class DancerPointSubmitter : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> submitPoints;
    [SerializeField] private UnityEvent lowerHand;
    [SerializeField] private UnityEvent upperHand;
    private float _lastValue = 0f;
    private bool lastRotationFull = true;

    private void SubmitPoints()
    {
        submitPoints.Invoke((int)PromptController.Prompt.Dance);
    }

    public void SetValue(float value)
    {
        CalculateSubmission(value);
        _lastValue = value;
    }

    private void CalculateSubmission(float value)
    {
        if (lastRotationFull)
        {
            if (value < 0.5f && _lastValue >= 0.5f)
            {
                SubmitPoints();
                lastRotationFull = !lastRotationFull;
                lowerHand.Invoke();
            }
        }
        else
        {
            if (value > 0.5f && _lastValue <= 0.5f)
            {
                SubmitPoints();
                lastRotationFull = !lastRotationFull;
                upperHand.Invoke();
            }
        }
    }
    
}