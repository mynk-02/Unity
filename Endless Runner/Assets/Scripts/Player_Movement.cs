using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    public int lives = 3;
    public float speed = 5f;
    public float speedIncreasePerPoint = 0.1f;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2f;
    bool alive = true;

    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;

    private void FixedUpdate()
    {
        if (!alive)
        {
            rb.freezeRotation= false;
            return;
        }

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (lives <= 0) { Die(); }

        if (transform.position.y < -5) { Die(); }
    }

    public void Die()
    {
        alive = false;
        Invoke("Restart", 2);
    }
    private void Restart()
    {
        //Restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        //Check whether player is grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.2f, groundMask);

        if (!isGrounded) { return; }
        //If grounded then jump
        rb.AddForce(Vector3.up * jumpForce);
    }
}
