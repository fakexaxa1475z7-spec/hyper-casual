using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CTBackground2 : MonoBehaviour
{
    public float speed = 1.5f;
    public float needScore = 20f;
    public float score = Score.instance.GetScore();
    public float fadeDuration = 2f;
    Image img;

    void Start()
    {
        img = GetComponent<Image>();
    }

    IEnumerator FadeOut()
    {
        float t = 0f;
        Color c = img.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(1f, 0f, t / fadeDuration);
            img.color = c;
            yield return null;
        }

        c.a = 0f;
        img.color = c;
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (score > needScore)
        {
            StartCoroutine(FadeOut());
        }
    }
}