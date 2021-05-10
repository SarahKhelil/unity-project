using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManger : MonoBehaviour
{

    public static ScoreManger instance ; 

    public Text scoreText ; 
    public Text highscoreText ; 

    int score = 0 ; 
    int highscore;


    private void Awake() {
        instance = this;
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore",0) ; 
        
    }

    public void update()
    {
        scoreText.text = score.ToString() ; 
        highscoreText.text = highscore.ToString();
    }

    public void AddPoint() 
    {
        score +=1; 
        scoreText.text = score.ToString();

        if (highscore<score)
        PlayerPrefs.SetInt("highscore",score) ;
        
    }
}
