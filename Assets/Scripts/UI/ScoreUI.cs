using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public static int scoreValue = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreEndGameText;
    private string currentScore = string.Format("{0, 1:D4}", scoreValue);
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreDisplay(scoreValue);
    }

    private void UpdateScoreDisplay(int score)
    {
        currentScore = string.Format("{0, 1:D4}", scoreValue);
        scoreText.text = currentScore.ToString();
        scoreEndGameText.text = currentScore.ToString();
    }
}
