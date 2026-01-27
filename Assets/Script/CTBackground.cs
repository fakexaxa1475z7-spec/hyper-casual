using UnityEngine;

public class CTBackground : MonoBehaviour
{
    public float speed = 1.5f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            transform.position = new Vector2(0, 10f);
        }
    }
}
