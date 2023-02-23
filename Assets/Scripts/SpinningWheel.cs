using UnityEngine;
using UnityEngine.Events;

public class SpinningWheel : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _baseAngle;
    [SerializeField] private UnityEvent<float> normalizedValue;
    [SerializeField] private int fullRotation;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        var pos = Camera.main!.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        _baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        _baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
    }

    void OnMouseDrag()
    {
        var pos = Camera.main!.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        var ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - _baseAngle;
        _rigidbody2D.MoveRotation(Quaternion.AngleAxis(ang, Vector3.forward));
        normalizedValue.Invoke(transform.eulerAngles.z / fullRotation);
    }
}
