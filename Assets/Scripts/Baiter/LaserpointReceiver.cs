using UnityEngine;

public class LaserpointReceiver : MonoBehaviour
{
    [SerializeField] private GameObject pointerLight;
    private Transform _currentLight;
    private Vector2 _mousePosition;

    public void OnMouseDown()
    {
        if(_currentLight)
            Destroy(_currentLight.gameObject);
        _currentLight = Instantiate(pointerLight).transform;
        _currentLight.position = _mousePosition;
    }

    public void OnMouseUp()
    {
        Destroy(_currentLight.gameObject);
    }


    private void FixedUpdate()
    {
        _mousePosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        if (_currentLight)
        {
            _currentLight.transform.position = _mousePosition;
        }
    }

    public void GracefulExit()
    {
        if(_currentLight)
            Destroy(_currentLight.gameObject);
    }
}