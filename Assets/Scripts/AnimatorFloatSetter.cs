using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFloatSetter : MonoBehaviour
{
    [SerializeField] private string propertyName;
    public float value;
    private Animator _animator;
    private void Update()
    {
        _animator.SetFloat(propertyName, value);
    }
}
