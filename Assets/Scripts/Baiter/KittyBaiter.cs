using UnityEngine;

public class KittyBaiter : PromptAction
{
    [SerializeField] private GameObject goal;
    [SerializeField] private LaserpointReceiver receiver;
    public PointerGoal instGoal;

    protected override void DoAction(PromptController.Prompt currentPrompt)
    {
        if (currentPrompt.Equals(prompt))
        {
            foreach (Transform t in transform)
            {
                if (t.gameObject.Equals(gameObject)) continue;
                t.gameObject.SetActive(true);
            }
            SpawnGoal();
        }
        else
        {
            if(receiver != null)
                receiver.GracefulExit();
            if(instGoal != null)
                Destroy(instGoal.gameObject);
            foreach (Transform t in transform)
            {
                if (t.gameObject.Equals(gameObject)) continue;
                t.gameObject.SetActive(false);
            }
        }
    }

    public void SpawnGoal()
    {
        instGoal = Instantiate(goal,
            Camera.main!.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, .9f), Random.Range(0.1f, .9f), 10f)),
            Quaternion.identity).GetComponent<PointerGoal>();
        instGoal.controller = controller;
        instGoal.baiter = this;
    }
}