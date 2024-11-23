using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    private int _score = 0;
    private void Start()
    {
        EventBus.Instance.onStartRace += UpdateScoreView;
    }
    
    private void UpdateScoreView()
    {
        _score++;
        _scoreView.SetScore(_score.ToString());
    }

    private void OnDestroy()
    {
        EventBus.Instance.onStartRace -= UpdateScoreView;
    }
}
