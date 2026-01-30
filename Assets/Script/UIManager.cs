using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Start")]
    public GameObject startUI;

    [Header("HUD")]
    public GameObject scoreUI;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    [Header("Game Over")]
    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;
    public TMP_Text bestScoreText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(false);
        startUI.gameObject.SetActive(true);
        scoreUI.gameObject.SetActive(true);
    }

    void Update()
    {
        scoreText.text = GameManager.instance.score.ToString();
        highScoreText.text = GameManager.instance.highScore.ToString();
    }

    public void GameStart()
    {
        startUI.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        scoreUI.gameObject.SetActive(false);
        finalScoreText.text = GameManager.instance.score.ToString();
        bestScoreText.text = GameManager.instance.highScore.ToString();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
