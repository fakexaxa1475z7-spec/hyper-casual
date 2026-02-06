using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public int highScore;

    float timer;
    bool isGameOver;

    public bool isNewHighScore;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        if (isGameOver) return;

        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            score += 1;
            timer -= 1f;
        }
    }

    public void GameOver()
    {
         if (isGameOver) return;
        isGameOver = true;

        if (score > highScore)
        {
            isNewHighScore = true;
            highScore = score;

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        else
        {
            isNewHighScore = false;
        }

        UIManager.instance.ShowGameOver();
        Time.timeScale = 0f;
    }
}
