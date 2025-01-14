using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] GameObject finishPanel;
    [SerializeField] GameManager gameManager;
    void Start()
    {
        BallController.Instance.onScore += UpdateScore;
        BallController.Instance.onFinish += GetFinishPanel;
    }
    private void UpdateScore(object p)
    {
        scoreText.text = $"{++GameManager.score}";
    }
    private void GetFinishPanel()
    {
        gameManager.UpdateHighScore();
        highScoreText.text = $"{gameManager.highScore}";
        finishPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        finishPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
