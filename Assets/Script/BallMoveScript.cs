using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveScript : MonoBehaviour
{
    LogicScript logicScript;

    float moveSpeedX;
    float moveSpeedY;

    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
        moveSpeedX = -3;
        valueYChanged();
    }

    // Update is called once per frame
    void Update()
    {
        if (!logicScript.IsStart)
            return;

        transform.position += (Vector3.right * moveSpeedX) * Time.deltaTime;
        transform.position += (Vector3.up * moveSpeedY) * Time.deltaTime;

        if (transform.position.x > 15)
            moveSpeedX = -10;
        if (transform.position.x < -15)
            moveSpeedX = 10;

        if (transform.position.y > 5)
            moveSpeedY = -5;
        if (transform.position.y < -5)
            moveSpeedY = 5;
    }

    public void ChangeValueX()
    {
        moveSpeedX = -moveSpeedX;
    }

    public void ChangeValueY()
    {
        moveSpeedY = -moveSpeedY;
    }

    public void BallToZero()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        SideBallChanged();
        logicScript.endRound();
    }

    public void AugmenteVitesse()
    {
        if (moveSpeedX < 0f)
            moveSpeedX--;
        else
            moveSpeedX += 1;
    }

    public void SideBallChanged()
    {
        if (logicScript.playerScoreRight > logicScript.playerScoreLeft)
            moveSpeedX = -3;
        else
            moveSpeedX = 3;

        valueYChanged();
    }

    public void valueYChanged()
    {
        var nb = Random.Range(1, 100);
        if(nb%2 == 0)
            moveSpeedY = Random.Range(1, 3);
        else
            moveSpeedY = Random.Range(-3, -1);
    }
}
