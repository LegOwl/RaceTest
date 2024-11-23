using UnityEngine;
using UnityEngine.UI;


public class TimerController : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private TimerView _timerView;
    [SerializeField] private int _countdown = 3;

    private void Start()
    {
        _startButton.onClick.AddListener(StartCountdown);
        EventBus.Instance.onCountdownStart += StartCountdown;
    }

    private void StartCountdown()
    {
        _startPanel.gameObject.SetActive(false);
        _timerView.StartCountdown(_countdown);
    }
    
    private void OnDestroy()
    {
        EventBus.Instance.onFinishRace -= StartCountdown;
    }
}