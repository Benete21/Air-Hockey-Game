using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour

{
    public ScoreScript ScoreScriptInstance;
    private Rigidbody2D rb;
    public static bool WasGoal { get; private set; }
    public float MaxSpeed;
    public Transform BoundarysPuck;
    Boundary puckBoundary;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
        puckBoundary = new Boundary(BoundarysPuck.GetChild(0).position.y,
                              BoundarysPuck.GetChild(1).position.y,
                              BoundarysPuck.GetChild(2).position.x,
                              BoundarysPuck.GetChild(3).position.x);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.tag == "AIGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.PlayerScore);
                WasGoal = true;
                StartCoroutine(ResetPuck(false));
            }
            else if (other.tag == "PlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.AiScore);
                WasGoal = true;
                StartCoroutine(ResetPuck(true));
            }
        }
    }

    private IEnumerator ResetPuck(bool didAiScore)
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);

        if (didAiScore)
            rb.position = new Vector2(2, 0);
        else
            rb.position = new Vector2(-2, 0);
    }

    public void CenterPuck()
    {
        rb.position = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }
}
