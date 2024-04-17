using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public enum Score
    {
        AiScore, PlayerScore
    }

   public Text AiScoretxt, PlayerScoretxt;
    private int aiScore, playerScore;
    public UIManager uiManager;
    public int MaxScore;

    private int AiScore
    {
        get { return aiScore; }
        set
        {
            aiScore = value;
            if (value == MaxScore)
                uiManager.showRestart(true);
        }
    }

    private int PlayerScore
    {
        get { return playerScore; }
        set
        {
            playerScore = value;
            if (value == MaxScore)
                uiManager.showRestart(false);
        }
    }


    public void Increment(Score whichScore)
    {
        if (whichScore == Score.AiScore)
        {
            AiScoretxt.text = (++AiScore).ToString();
        }         
        else
        {
            PlayerScoretxt.text = (++PlayerScore).ToString();
        }           
    }

    public void ResetScores()
    {
        AiScore = PlayerScore = 0;
        AiScoretxt.text = PlayerScoretxt.text = "0";
    }

}

