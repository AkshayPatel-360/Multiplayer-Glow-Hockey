using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    public ScoreScript ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.tag == "AiGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.PLAYER_SCORE);
                WasGoal = true;
                StartCoroutine(ResetPuck());
                
            }
            else if (other.tag == "PlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.AI_SCORE);
                WasGoal = true;
                StartCoroutine(ResetPuck());
            }
        }
    }

    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerGoal")
        {
            Debug.Log("hasdnvv");
        }
    }

    private IEnumerator ResetPuck()
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);
    }
}
