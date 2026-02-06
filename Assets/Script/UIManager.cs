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

    [Header("Audio")]
    public AudioSource gameOverSFX; 
    public AudioSource highScoreSFX; 

    BGMManager bgm; 

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
        startUI.SetActive(true);
        scoreUI.SetActive(true);

        bgm = FindObjectOfType<BGMManager>();
    }

    void Update()
    {
        scoreText.text = GameManager.instance.score.ToString();
        highScoreText.text = GameManager.instance.highScore.ToString();
    }

    public void GameStart()
    {
        startUI.SetActive(false);
        Time.timeScale = 1f;

        if (bgm != null)
            bgm.PlayBGM();
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        scoreUI.SetActive(false);

        finalScoreText.text = GameManager.instance.score.ToString();
        bestScoreText.text = GameManager.instance.highScore.ToString();

        if (bgm != null)
            bgm.StopBGM();

        if (GameManager.instance.isNewHighScore)
        {
            if (highScoreSFX != null)
                highScoreSFX.Play();
        }
        else
        {
            if (gameOverSFX != null)
                gameOverSFX.Play();
        }
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
