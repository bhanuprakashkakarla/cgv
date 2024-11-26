using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class ZoneDeadScript : MonoBehaviour
{
    BallMoveScript ballMoveScript;
    LogicScript logicScript;

    // Start is called before the first frame update
    void Start()
    {
        ballMoveScript = GameObject.FindGameObjectWithTag("ball").GetComponent<BallMoveScript>();
        logicScript = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.position.x > 0)
            logicScript.addScorePlayerLeft();
        else if (collision.transform.position.x < 0)
            logicScript.addScorePLayerRight();

        ballMoveScript.BallToZero();

        if(logicScript.playerScoreLeft == 10 ||logicScript.playerScoreRight == 10)
            logicScript.restartGame();

    }
}
