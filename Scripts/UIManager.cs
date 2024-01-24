using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool gameOver = false;

    private int score = 0;
    private int hScore = 0;

    [SerializeField] private Text scoreText = null;
    [SerializeField] private Text GameOverText = null;
    [SerializeField] private Text PlayAgain = null;
    [SerializeField] private Text HighScore = null;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + 0;
        GameOverText.text = "GRAY GUN";
        PlayAgain.text = "Press ENTER to play";
        HighScore.gameObject.SetActive(false);
        hScore = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (score > hScore)
            {
                hScore = score;
                PlayerPrefs.SetInt("HighScore", hScore);
            }
            GameOverText.text = "GAME OVER";
            PlayAgain.text = "Press ENTER to play again";
            HighScore.text = "High Score: " + hScore;
            GameOverText.gameObject.SetActive(true);
            PlayAgain.gameObject.SetActive(true);
            HighScore.gameObject.SetActive(true);
        }
    }

    public void updateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void resetScore()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    public void hideText()
    {
        GameOverText.gameObject.SetActive(false);
        PlayAgain.gameObject.SetActive(false);
        HighScore.gameObject.SetActive(false);
    }

    public void showPaused()
    {
        GameOverText.text = "PAUSED";
        PlayAgain.text = "Press ESCAPE to resume";
        GameOverText.gameObject.SetActive(true);
        PlayAgain.gameObject.SetActive(true);
    }
}
