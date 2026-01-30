using UnityEngine;

public class CTBackground : MonoBehaviour
{
    public float startSpeed = 1.5f;
    public float maxSpeed = 8f;


    void FixedUpdate()
    {
        // ความเร็วเพิ่มตาม score
        float currentSpeed = startSpeed + (GameManager.instance.score * 0.02f);
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

        transform.Translate(Vector2.down * currentSpeed * Time.fixedDeltaTime);

        if (transform.position.y < -10.8f)
        {
            transform.position = new Vector2(0, 12.6f);
        }
    }
}
