using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    void Update()
    {
        scoreText.text = GameManager.instance.score.ToString(); ;
        highScoreText.text = GameManager.instance.highScore.ToString(); ;
    }
}