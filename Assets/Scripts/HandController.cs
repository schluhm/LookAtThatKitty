using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    [SerializeField] private float despawnTime = 5f;
    [SerializeField] private PromptController controller;
    
    public void OnMouseDown()
    {
        SpawnParticles();
        transform.Rotate(Vector3.forward * -45);
        controller.ReportActionSuccess((int)PromptController.Prompt.Pet);
    }

    public void OnMouseUp()
    {
        transform.Rotate(Vector3.forward * 45);
    }
    
    public void SpawnParticles()
    {
        Destroy(Instantiate(particles), despawnTime);
    }
}
