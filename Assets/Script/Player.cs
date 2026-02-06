using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float bounceForce = 5f;

    Rigidbody2D rb;
    SpriteRenderer sr;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (move > 0)
            sr.flipX = true;
        else if (move < 0)
            sr.flipX = false;

        if (transform.position.y < Camera.main.transform.position.y - 7f)
        {
            GameManager.instance.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Platform")) return;

        if (rb.velocity.y > 0f) return;

        Bounce();
    }

    void Bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
    }
}
