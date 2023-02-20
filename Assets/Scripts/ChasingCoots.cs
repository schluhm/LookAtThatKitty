using UnityEngine;

public class ChasingCoots : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private Animator _animator;
    [SerializeField] private float speed;

    private static readonly int Speed = Animator.StringToHash("Speed");

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var position = _rigidbody2D.position;
        _rigidbody2D.MovePosition(position + (PointerPosition.PointerPos - position)* speed);
        _animator.SetFloat(Speed, _rigidbody2D.velocity.normalized.magnitude);
    }
}
