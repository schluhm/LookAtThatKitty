using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Catfood : MonoBehaviour
{
    [SerializeField] private float speed;
    public KittyFeeder feeder;
    private Vector2 _mousePosition;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float incomingSpeed;
    private Vector2 _spawnPoint;
    private bool clicked;


    private void Start()
    {
        _spawnPoint = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(nameof(ThrowIn));
    }

    private IEnumerator ThrowIn()
    {
        var startTime = Time.time;
        var targetPosition = transform.position;
        if (targetPosition.x > feeder.worldUpperBounds.x)
            targetPosition = new Vector3(feeder.worldUpperBounds.x - feeder.worldBoundDiff.x * 0.2f, targetPosition.y,
                10f);
        if (targetPosition.x < feeder.worldLowerBounds.x)
            targetPosition = new Vector3(feeder.worldLowerBounds.x + feeder.worldBoundDiff.x * 0.2f, targetPosition.y,
                10f);
        if (targetPosition.y > feeder.worldUpperBounds.y)
            targetPosition = new Vector3(targetPosition.x, feeder.worldLowerBounds.y - feeder.worldBoundDiff.y * 0.2f,
                10f);
        if (targetPosition.y < feeder.worldLowerBounds.y)
            targetPosition = new Vector3(targetPosition.x, feeder.worldLowerBounds.y + feeder.worldBoundDiff.y * 0.2f,
                10f);

        while (Time.time < startTime + incomingSpeed)
        {
            _rigidbody2D.velocity = targetPosition - transform.position;
            yield return null;
        }
    }

    private IEnumerator ThrowOut()
    {
        var startTime = Time.time;
        var targetPosition = new Vector3(_spawnPoint.x, _spawnPoint.y, 10f);
        while (Time.time < startTime + incomingSpeed)
        {
            _rigidbody2D.velocity = targetPosition - transform.position;
            yield return null;
        }

        DestroyFood(true);
    }

    public void OnMouseDown()
    {
        clicked = true;
    }

    private void FixedUpdate()
    {
        if(!clicked) return;
        var position = _rigidbody2D.position;
        _rigidbody2D.MovePosition(position + ((Vector2) Camera.main!.ViewportToWorldPoint(new Vector2(0.5f, 0f)) - position) * speed);
    }

    public void DestroyFood(bool fed)
    {
        feeder.foods.Remove(this);
        if (fed)
            Destroy(gameObject);
        else
        {
            StopAllCoroutines();
            StartCoroutine(nameof(ThrowOut));
        }
    }
}