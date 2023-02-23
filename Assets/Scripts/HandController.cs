using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    [SerializeField] private float despawnTime = 5f;
    [SerializeField] private PromptController controller;
    
    public void OnMouseDown()
    {
        SpawnParticles();
        transform.rotation = Quaternion.Euler(0, 0, 0);
        controller.ReportActionSuccess((int)PromptController.Prompt.Pet);
    }

    public void OnMouseUp()
    {
        transform.rotation = Quaternion.Euler(0, 0, 45);
    }
    
    public void SpawnParticles()
    {
        Destroy(Instantiate(particles), despawnTime);
    }
}
