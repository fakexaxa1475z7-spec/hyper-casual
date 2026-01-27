using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 1.5f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -5.5f)
        {
            Destroy(gameObject);
        }
    }
}
