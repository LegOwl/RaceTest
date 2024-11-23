using System.Collections;
using UnityEngine;
using TMPro;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    private int _countdown;
    private void Start()
    {
        countdownText.text = "";
    }
    
    public void StartCountdown(int seconds)
    {
        _countdown = seconds;
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine() // Отсчет перед заездом
    {
        while (_countdown > 0)
        {
            countdownText.text = _countdown.ToString();
            yield return new WaitForSeconds(1f);
            _countdown--;
        }

        EventBus.Instance.StartRace();
        countdownText.text = "Go!";
        
        yield return new WaitForSeconds(1f);
        countdownText.text = "";
    }
}
