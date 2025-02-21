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
                if (hit.collider.CompareTag("Brick"))
                {
                    Destroy(hit.collider.gameObject); 
                }
                else if (hit.collider.CompareTag("QuestionBlock"))
                {
                    FindFirstObjectByType<GameManager>().AddCoin(); 
                }
            }
        }
    }
}

