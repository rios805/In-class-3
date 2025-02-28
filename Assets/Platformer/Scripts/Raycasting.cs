using UnityEngine;

public class Raycasting : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameManager gameManager = FindFirstObjectByType<GameManager>(); 

                if (hit.collider.CompareTag("Brick"))
                {
                    gameManager.AddBrickPoints(); 
                    Destroy(hit.collider.gameObject); 
                }
                else if (hit.collider.CompareTag("QuestionBlock"))
                {
                    gameManager.AddCoin();
                }
            }
        }
    }
}

