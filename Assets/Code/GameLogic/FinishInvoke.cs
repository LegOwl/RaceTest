using UnityEngine;

public class FinishInvoke : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.Instance.FinishRace();
        }
    }
}