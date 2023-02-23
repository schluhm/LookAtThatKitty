using UnityEngine;

public class AnimatorTimeControl : MonoBehaviour
{
    private Animator _anim;
    private float _normalizedValue;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.speed = 0;
    }


    // Update is called once per frame
    void Update()
    {
        _anim.Play("luddy", -1, _normalizedValue);
    }

    public void SetValue(float value)
    {
        _normalizedValue = value;
    }
}