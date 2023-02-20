using UnityEngine;

public class FoodReceiver : MonoBehaviour
{
    [SerializeField] private PromptController controller;

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("2d collision");
        if (col.gameObject.GetComponent<Catfood>())
        {
            controller.ReportActionSuccess((int)PromptController.Prompt.Feed);
            col.gameObject.GetComponent<Catfood>().DestroyFood(true);
        }
    }
}
