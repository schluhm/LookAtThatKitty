using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Baiter
{
    public class PointerGoal : MonoBehaviour
    {
        [SerializeField] private List<Color> colors;
        public PromptController controller;
        public KittyBaiter baiter;

        private void Awake()
        {
            GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Count)];
        }

        private void Update()
        {
            if(baiter.instGoal != this) Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log("COLLIDING WITH CHASING COOTS");
            if (col.gameObject.GetComponent<ChasingCoots>())
            {
                controller.ReportActionSuccess((int)PromptController.Prompt.Bait);
                baiter.SpawnGoal();
                Destroy(gameObject);
            }
        }
    
    }
}
