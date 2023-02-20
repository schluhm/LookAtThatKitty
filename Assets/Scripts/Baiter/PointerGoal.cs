using UnityEngine;

public class PointerGoal : MonoBehaviour
{
    public PromptController controller;
    public KittyBaiter baiter;

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
