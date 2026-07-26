using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public float moveSpeed = 5f;
    public float jumpPower = 7f;

    bool isGround = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(
            x * moveSpeed,
            rb.velocity.y,
            0
        );

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

        if (transform.position.y < -5)
        {
            transform.position = new Vector3(0, 1, 0);
            rb.velocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}