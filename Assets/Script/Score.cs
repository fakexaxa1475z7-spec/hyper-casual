using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static Score instance;
    private int score = 0;

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public int GetScore()
    {
        return score;
    }
}
