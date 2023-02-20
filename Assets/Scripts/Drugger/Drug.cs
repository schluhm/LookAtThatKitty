using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drug : MonoBehaviour
{
    [SerializeField] private DrugType drugType;
    public PromptController controller;
    public KittyDrugger drugger;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<HungryCoots>())
        {
            controller.ReportActionSuccess((int)PromptController.Prompt.Drug);
            Destroy(gameObject);
        }
    }
    
    

    public void DestroyDrug(bool used)
    {
        drugger.spawnedDrugs.Remove(this);
        if (used)
            Destroy(gameObject);
        else
        {
            StopAllCoroutines();
            StartCoroutine(nameof(ThrowOut));
        }
    }

    private IEnumerator ThrowOut()
    {
        var startTime = Time.time;
        var endTime = 0.3f;
        var direction = Camera.main!.WorldToViewportPoint(transform.position).x > 0.5f ? 1f : -1f;

        while (Time.time < startTime + endTime)
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + (Vector2)((endTime - (Time.time - startTime) / endTime) *
                                                                        Camera.main!.ViewportToWorldPoint(
                                                                            new Vector3(direction, 0f))));
            yield return null;
        }

        DestroyDrug(true);
    }

    enum DrugType
    {
        Baldrian,
        Weed,
        Katzenminze
    }
}