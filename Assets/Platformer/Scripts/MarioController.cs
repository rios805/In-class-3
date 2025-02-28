using UnityEngine;

public class MarioController : MonoBehaviour
{
    public float acceleration = 3f;
    public float maxspeed = 10f;
    public float jumpImpulse = 8f;
    public float jumpBoostForce = 8f;
    public bool isGrounded;
    Rigidbody rb;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalAmount = Input.GetAxis("Horizontal");
        rb.linearVelocity += Vector3.right * horizontalAmount * Time.deltaTime * acceleration;

        float horizontalSpeed = rb.linearVelocity.x;
        horizontalSpeed = Mathf.Clamp(horizontalSpeed, -maxspeed, maxspeed);

        Vector3 newVelocity = rb.linearVelocity;
        newVelocity.x = horizontalSpeed;
        rb.linearVelocity = newVelocity;

     
        Collider c = GetComponent<Collider>();
        Vector3 startPoint = transform.position;
        float castDistance = c.bounds.extents.y + 0.01f;
        Color color = (isGrounded) ? Color.green : Color.red;
        Debug.DrawLine(startPoint, startPoint + castDistance * Vector3.down, color, duration:0f, depthTest:false);

        isGrounded = Physics.Raycast(startPoint, Vector3.down, castDistance);

   
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {  
            rb.AddForce(Vector3.up * jumpImpulse, ForceMode.VelocityChange);
        } 
        else if (Input.GetKey(KeyCode.Space) && !isGrounded && rb.linearVelocity.y > 0) 
        {
            rb.AddForce(Vector3.up * jumpBoostForce * Time.deltaTime, ForceMode.VelocityChange); 
        }

        if (!isGrounded && rb.linearVelocity.y > 0) 
        {
            CheckForBlockAbove();
        }

     
        if (horizontalAmount == 0f)
        {
            Vector3 decayedVelocity = rb.linearVelocity;
            decayedVelocity.x *= 1f - Time.deltaTime * 4f;
            rb.linearVelocity = decayedVelocity;
        }
        else
        {
            float yawRotation = (horizontalAmount > 0f) ? 90f : -90f;
            transform.rotation = Quaternion.Euler(0f, yawRotation, 0f);
        }

       
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetBool("In Air", !isGrounded);
    }

    
    void CheckForBlockAbove()
    {
        RaycastHit hit;
        Vector3 rayOrigin = transform.position + Vector3.up * 0.6f;
        float rayDistance = 1.2f; 

        Debug.DrawRay(rayOrigin, Vector3.up * rayDistance, Color.red, 1f); // Debug the ray

        if (Physics.Raycast(rayOrigin, Vector3.up, out hit, rayDistance))
        {
            Debug.Log("Hit Block: " + hit.collider.name + " | Tag: " + hit.collider.tag); 

            GameManager gameManager = FindFirstObjectByType<GameManager>();

            if (hit.collider.CompareTag("Brick"))
            {
                Debug.Log("Brick Broken!");
                gameManager.AddBrickPoints();
                Destroy(hit.collider.gameObject);
            }
            else if (hit.collider.CompareTag("QuestionBlock"))
            {
                Debug.Log("Question Block Hit!");
                QuestionBlock qb = hit.collider.GetComponent<QuestionBlock>();
                if (qb != null)
                {
                    qb.HitBlock();
                }
                gameManager.AddCoin();
            }
        }
    }




}

