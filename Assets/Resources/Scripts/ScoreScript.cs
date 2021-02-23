using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
   public enum Score
    {
        AI_SCORE,PLAYER_SCORE
    }
    public Text AiScoreTxt, PlayerScoreTxt;
    private int aiScore, playerScore;

    public void Increment(Score whichScore)
    {
        if (whichScore == Score.AI_SCORE)
            AiScoreTxt.text = (++aiScore).ToString();
        else
            PlayerScoreTxt.text = (++playerScore).ToString();
    }
}
