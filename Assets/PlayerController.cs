using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // 移動速度
    public float moveSpeed = 6.0f;
    // ジャンプ力
    public float jumpForce = 5.0f;
    // 落下リスタートする高さ
    public float fallLimitY = -5.0f;

    private Rigidbody rb;
    private bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 左右移動
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0f);

        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // 落下判定
        if (transform.position.y < fallLimitY)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 接地判定
        isGrounded = true;
    }

private void OnTriggerEnter(Collider other)
    {
        // ゴール判定
        if (other.CompareTag("Goal"))
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}