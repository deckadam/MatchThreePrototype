using TMPro;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour
{
    private TextMeshProUGUI _scoreDisplayer;

    private void Start()
    {
        _scoreDisplayer = GetComponent<TextMeshProUGUI>();
        MatchChecker.OnScoreChanged += UpdateScore;
    }

    private void OnDestroy()
    {
        MatchChecker.OnScoreChanged -= UpdateScore;
    }

    private void UpdateScore(int newScore)
    {
        _scoreDisplayer.text = "Score : " + newScore;
    }
}