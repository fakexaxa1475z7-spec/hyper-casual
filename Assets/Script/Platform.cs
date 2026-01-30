using UnityEngine;

public class Platform : MonoBehaviour
{
    public float startSpeed = 1.5f;
    public float maxSpeed = 8f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // ความเร็วเพิ่มตาม score
        float currentSpeed = startSpeed + (GameManager.instance.score * 0.02f);
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

        rb.MovePosition(rb.position + Vector2.down * currentSpeed * Time.fixedDeltaTime);

        if (transform.position.y < Camera.main.transform.position.y - 8f)
        {
            Destroy(gameObject);
        }
    }
}
