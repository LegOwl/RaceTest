using UnityEngine;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private GameObject endGamePanel;
    private void Start()
    {
        EventBus.Instance.onEndGame += ShowPanel;
    }
    private void ShowPanel()
    {
        endGamePanel.SetActive(true);
    }
}
