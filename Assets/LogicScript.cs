using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int playerScore;
    public GameObject gameOverScreen;
    public Text score;
    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore += 1;
        score.text = playerScore.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
