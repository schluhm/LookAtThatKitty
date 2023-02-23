using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class KittyFeeder : PromptAction
{
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private float foodTimer = 0.2f;
    public Camera mainCamera;
    public List<Catfood> foods;
    private float _timer = 1f;
    public Vector2 worldUpperBounds;
    public Vector2 worldLowerBounds;
    public Vector2 worldBoundDiff;
    private bool spawningFoods;

    internal new void Start()
    {
        base.Start();
        worldUpperBounds = mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f, 10f));
        worldLowerBounds = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 10f));
        worldBoundDiff = worldUpperBounds - worldLowerBounds;
    }
    
    protected override void DoAction(PromptController.Prompt currentPrompt)
    {
        if (!prompt.Equals(currentPrompt))
        {
            spawningFoods = false;
            DestroyFoods();
        }
        else
        {
            spawningFoods = true;
            _timer = 0f;
        }
        
        
    }

    private void Update()
    {
        if (!spawningFoods) return;
        if (!controller.state.Equals(prompt)) return;
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            SpawnFood();
            _timer = foodTimer;
        }
    }

    private void SpawnFood()
    {
        var fromSide = Random.Range(0, 2) == 0;
        var coinFlip = Random.Range(0, 2) == 0;
        var x = 0f;
        var y = 0f;
        if (fromSide)
        {
            x = ((coinFlip ? -0.1f : 1.1f) * worldBoundDiff.x) + worldLowerBounds.x;
            y = (Random.Range(0f, 1f) * worldBoundDiff.y) + worldLowerBounds.y;
        }
        else
        {
            x = (Random.Range(0f, 1f) * worldBoundDiff.x) + worldLowerBounds.x;
            y =  1.1f * worldBoundDiff.y + worldLowerBounds.y;
        }
        var spawnPoint = new Vector3(x, y, 10f);
        var newFood = Instantiate(foodPrefab, spawnPoint, Quaternion.identity);
        newFood.GetComponent<Catfood>().feeder = this;
        foods.Add(newFood.GetComponent<Catfood>());

    }

    private void DestroyFoods()
    {
        foreach (var f in foods.ToList())
        {
            f.DestroyFood(false);
        }
    }
}
