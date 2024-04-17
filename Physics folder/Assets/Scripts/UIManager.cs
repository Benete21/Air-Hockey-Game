using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject CanvaGame;
    public GameObject CanvaRestart;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LoseTxt;

    [Header("Other")]
    public ScoreScript ScoreScript;
    public PuckScript Puck;
    public Movment Movement;
    public AI AI;
    public portalSpawner portalSpawner;

    public void showRestart(bool AIWin)
    {
        Time.timeScale = 0;

        CanvaGame.SetActive(false);
        CanvaRestart.SetActive(true);

        if (AIWin)
        {
            WinTxt.SetActive(false);
            LoseTxt.SetActive(true);
        }
        else
        {
            WinTxt.SetActive(true);
            LoseTxt.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        CanvaGame.SetActive(true);
        CanvaRestart.SetActive(false);

        ScoreScript.ResetScores();
        Puck.CenterPuck();
        Movement.ResetPosition();
        AI.ResetPosition();
        portalSpawner.ResetPortalPosition();
    }
}



