using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreText;

    private int coins = 0;
    private int score = 0;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        int timeLeft = 300 - (int)(Time.time);
        timerText.text = $"Time: {timeLeft}";
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

    void UpdateUI()
    {
         coinText.text = $"x{coins.ToString("D2")}"; 
        scoreText.text = $"{score.ToString("D6")}";
    }
}

