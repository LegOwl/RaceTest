using UnityEngine;
using TMPro;
public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void SetScore(string str)
    {
        scoreText.text = "Заезд: " + str;
    }
}
