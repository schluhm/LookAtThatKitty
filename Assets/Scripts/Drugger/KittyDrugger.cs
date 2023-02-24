using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;
using Random = UnityEngine.Random;


namespace Drugger
{
    public class KittyDrugger : PromptAction
    {
        [SerializeField] private RigidbodyMouseFollower drugMover;
        [SerializeField] private List<GameObject> drugs;
        public List<Drug> spawnedDrugs;
        private bool _activated;
        [SerializeField] private float drugTime = 0.2f;
        private float _timer;
        public Vector2 worldUpperBounds;
        public Vector2 worldLowerBounds;
        public Vector2 worldBoundDiff;
    
    
        internal new void Start()
        {
            base.Start();
            worldUpperBounds = Camera.main!.ViewportToWorldPoint(new Vector3(1f, 1f, 10f));
            worldLowerBounds = Camera.main!.ViewportToWorldPoint(new Vector3(0f, 0f, 10f));
            worldBoundDiff = worldUpperBounds - worldLowerBounds;
        }
    
        void Update()
        {
            if (!_activated) return;
            if (!controller.state.Equals(prompt)) return;
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                SpawnDrug();
                _timer = drugTime;
            }
        }

        private void SpawnDrug()
        {
            var coinFlip = Random.Range(0, 2);
            var x = ((coinFlip ==0 ? Random.Range(.05f, .2f) : Random.Range(.8f , .95f)) * worldBoundDiff.x) + worldLowerBounds.x;
            var y =  1.1f * worldBoundDiff.y + worldLowerBounds.y;
        
            var spawnPoint = new Vector3(x, y, 10f);
            var newDrug = Instantiate(drugs[Random.Range(0, drugs.Count)], spawnPoint, Quaternion.identity).GetComponent<Drug>();
            newDrug.drugger = this;
            newDrug.controller = controller;
            spawnedDrugs.Add(newDrug);
        }

        protected override void DoAction(PromptController.Prompt currentPrompt)
        {
            if (currentPrompt.Equals(prompt))
            {
                _activated = true;
                drugMover.gameObject.SetActive(true);
            }
            else
            {
                _activated = false;
                drugMover.gameObject.SetActive(false);
                DestroyDrugs();
            }
        }
    
        private void DestroyDrugs()
        {
            foreach (var f in spawnedDrugs.ToList())
            {
                if(f)
                    f.DestroyDrug(true);
            }
        }
    }
}
