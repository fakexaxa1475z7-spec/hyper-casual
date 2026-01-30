using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float bounceForce = 5f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // ตกนอกจอ = Game Over
        if (transform.position.y < Camera.main.transform.position.y - 7f)
        {
            GameManager.instance.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Platform")) return;

        // เด้งเฉพาะตอนตก
        if (rb.velocity.y > 0f) return;

        Bounce();
    }

    void Bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
    }
}
