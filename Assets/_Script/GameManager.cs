using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event EventHandler OnScoreChange;
    public event EventHandler OnLivesChange;

    private int score = 0;

    private int lives = 3;

    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseScore(int scoreToAdd)
    {
        Debug.Log(3);
        score += scoreToAdd;
        OnScoreChange?.Invoke(this, EventArgs.Empty);
    }

    public void DecreaseScore()
    {
        score += 100;
        OnScoreChange?.Invoke(this, EventArgs.Empty);
    }

    public int DecreaseLife()
    {
        lives--;
        if (lives < 1)
        {
            lives = 0;
        }
        OnLivesChange?.Invoke(this, EventArgs.Empty);
        return lives;
    }

    public int GetScore() => score;
    public int GetLives() => lives;
}
