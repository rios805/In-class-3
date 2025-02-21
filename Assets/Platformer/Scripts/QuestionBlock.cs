using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    public Material questionBlockMaterial; 
    private float yOffset = 0f;
    private int currentFrame = 0;
    private float frameDuration = 0.2f; 
    private float timer = 0f;
    
    void Start()
    {
        if (questionBlockMaterial == null)
            questionBlockMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= frameDuration)
        {
            timer = 0f;
            AnimateBlock();
        }
    }

    void AnimateBlock()
    {
        currentFrame = (currentFrame + 1) % 5; // Loop through 5 frames
        yOffset = -0.2f * currentFrame; // Shift texture down each frame
        Vector2 newOffset = new Vector2(questionBlockMaterial.mainTextureOffset.x, yOffset);
        questionBlockMaterial.mainTextureOffset = newOffset;
    }
}
