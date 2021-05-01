using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int score;
    public int Score { get; private set; }
    public static ScoreCounter instance;

    [SerializeField] TextMeshProUGUI[] scoreTextHolders;

    private void Awake()
    {
        if (ScoreCounter.instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("ScoreCounter instance already created");
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        UpdateScore();
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        UpdateScore();
    }

    public void GameOverMultiplicator(int multiplicator)
    {
        score *= multiplicator;
        UpdateScore();
    }

    private void UpdateScore()
    {
        Score = score;
        foreach (var text in scoreTextHolders)
        {
            text.text = "Score: " + Score;
        }
    }
}
