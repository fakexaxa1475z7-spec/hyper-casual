using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CTBackground2 : MonoBehaviour
{
    public float speed = 1.5f;
    public float needScore = 20f;
    public float fadeDuration = 2f;
    Image img;

    public float startSpeed = 1.5f;
    public float maxSpeed = 8f;

    void Start()
    {
        img = GetComponent<Image>();
    }

    void FixedUpdate()
    {
        float currentSpeed = startSpeed + (GameManager.instance.score * 0.02f);
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

        transform.Translate(Vector2.down * currentSpeed * Time.fixedDeltaTime);

        if (transform.position.y < -10.8f)
        {
            transform.position = new Vector2(0, 12.6f);
        }

        if (GameManager.instance.score > needScore)
        {
            Destroy(gameObject);
        }
    }
}