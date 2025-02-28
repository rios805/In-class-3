using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    private bool isUsed = false;

    public void HitBlock()
    {
        if (isUsed) return; // Prevent multiple activations
        isUsed = true;

        GameManager gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AddCoin(); // Add a coin and 100 points

    }
}


