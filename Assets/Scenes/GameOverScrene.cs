using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScrene : MonoBehaviour
{

    public void RestartButton() {
        SceneManager.LoadScene("Game");
                scorecoin.coinAmount = 0 ; 

    }

    public void EndButton() {
        SceneManager.LoadScene("menu");
    }
}
