using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketScript : MonoBehaviour
{
    public float MoveSpeed = 5f;  // Speed of the paddle movement
    public bool IsAIControlled;  // Toggle between AI and manual control
    public float MoveY;          // Amount of manual movement per key press

    public float minY = -4.5f;   // Minimum Y position (adjust based on your game)
    public float maxY = 4.5f;    // Maximum Y position (adjust based on your game)

    private Transform ballTransform; // Reference to the ball's transform for AI logic
    private BallMoveScript ballMoveScript; // Reference to the BallMoveScript for ball interactions

    // Start is called before the first frame update
    void Start()
    {
        ballTransform = GameObject.FindGameObjectWithTag("ball").transform; // Get ball's position
        ballMoveScript = GameObject.FindGameObjectWithTag("ball").GetComponent<BallMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAIControlled)
        {
            MoveAI(); // AI-controlled paddle movement
        }
        else
        {
            MoveManually(); // Manual paddle movement
        }

        // Clamp paddle position to prevent going out of bounds
        ClampPaddlePosition();
    }

    // AI-controlled movement
    private void MoveAI()
    {
        if (ballTransform != null)
        {
            // AI logic: Follow the ball's Y position smoothly
            float ballY = ballTransform.position.y;

            // Move towards the ball's Y position
            if (transform.position.y < ballY)
            {
                transform.position += new Vector3(0, MoveSpeed * Time.deltaTime, 0);
            }
            else if (transform.position.y > ballY)
            {
                transform.position -= new Vector3(0, MoveSpeed * Time.deltaTime, 0);
            }
        }
    }

    // Manual movement logic
    private void MoveManually()
    {
        if (gameObject.tag == "raquetRight")
        {
            PositionTouchRaquetChanged(KeyCode.UpArrow, KeyCode.DownArrow);
        }
        else if (gameObject.tag == "raquetLeft")
        {
            PositionTouchRaquetChanged(KeyCode.W, KeyCode.S);
        }
    }

    // Movement logic for manual control with key inputs
    private void PositionTouchRaquetChanged(KeyCode keyCodeUp, KeyCode keyCodeDown)
    {
        if (Input.GetKey(keyCodeUp))
        {
            transform.position += new Vector3(0, MoveSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(keyCodeDown))
        {
            transform.position -= new Vector3(0, MoveSpeed * Time.deltaTime, 0);
        }
    }

    // Prevent the paddle from going out of bounds
    private void ClampPaddlePosition()
    {
        transform.position = new Vector3(
            transform.position.x, 
            Mathf.Clamp(transform.position.y, minY, maxY), 
            transform.position.z
        );
    }

    // Collision logic for interaction with the ball
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ballMoveScript != null)
        {
            ballMoveScript.AugmenteVitesse();
            ballMoveScript.ChangeValueX();
        }
    }
}
