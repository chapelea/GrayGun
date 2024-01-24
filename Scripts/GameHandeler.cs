using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandeler : MonoBehaviour
{
    [SerializeField] private Spawner S = null;
    [SerializeField] private Background B = null;
    [SerializeField] private KillBar K = null;
    [SerializeField] private UIManager U = null;

    private bool playing = false;

    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        B.gameOver = true; // Stops background movement.

        S.gameOver = true; // Stops spawning enemies.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && playing)
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
                U.showPaused();
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
                U.hideText();
            }
        }

        if (!playing)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                playing = true;

                B.gameOver = false;

                S.BirthPlayer();
                S.gameOver = false;

                K.gameOver = false;

                U.gameOver = false;
                U.resetScore();
                U.hideText();
            }
        }
    }

    public void gameOver()
    {
        playing = false;

        B.gameOver = true; // Stops background movement.

        S.gameOver = true; // Stops spawning enemies.

        K.gameOver = true; // Kills remaining enemies.

        U.gameOver = true; // Displays game over message.
    }
}
