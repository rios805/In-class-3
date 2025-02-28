using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreText;

    private int coins = 0;
    private int score = 0;
    private float startTime;
    private int timeLimit = 100; 
    private bool gameEnded = false;

    void Start()
    {
        startTime = Time.time;
        UpdateUI();
    }

    void Update()
    {
        if (gameEnded) return; 

        int timeLeft = timeLimit - (int)(Time.time - startTime);
        timerText.text = $"Time: {timeLeft}";

        if (timeLeft <= 0)
        {
            EndGame(); 
        }
    }

    void EndGame()
    {
        gameEnded = true;
        Debug.Log("GAME OVER!");
    }

    public void AddCoin()
    {
        coins++;
        score += 100; 
        UpdateUI();
    }

    public void AddPoints(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void AddBrickPoints()
    {
        score += 100; 
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = $"x{coins.ToString("D2")}";
        scoreText.text = $"{score.ToString("D6")}";
    }
}

