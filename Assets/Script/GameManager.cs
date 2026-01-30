using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public int highScore;

    float timer;
    bool isGameOver;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        // âËÅ´ High Score
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
        isGameOver = true;
        UIManager.instance.ShowGameOver();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        Time.timeScale = 0f;
    }
}
