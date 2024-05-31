using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public int scoreToGet;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public TextMeshProUGUI youWinText;
    public Button playAgainButton;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
        isGameActive = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isGameActive == false)
        {
            RestartGame();
        }
        if(score >= scoreToGet)
        {
            EnoughPoints();
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void EnoughPoints()
    {
        youWinText.gameObject.SetActive(true);
        isGameActive = false;
        playAgainButton.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
