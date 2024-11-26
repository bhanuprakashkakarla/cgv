using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public GameObject Home;

    public int playerScoreLeft;
    public int playerScoreRight;

    public Text scoreTextPlayerLeft;
    public Text scoreTextPlayerRight;

    public bool IsStart;

    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && !IsStart)
        {
            Home.SetActive(false);
            IsStart = true;
        }
    }

    public void addScorePlayerLeft()
    {
        playerScoreLeft++;
        scoreTextPlayerLeft.text = playerScoreLeft.ToString();
    }
    public void addScorePLayerRight()
    {
        playerScoreRight++;
        scoreTextPlayerRight.text = playerScoreRight.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void endRound()
    {
        Home.SetActive(true);
        IsStart = false;
    }
}
