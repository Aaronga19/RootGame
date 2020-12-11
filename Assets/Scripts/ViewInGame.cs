using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : MonoBehaviour
{
    public static ViewInGame sharedInstance;

    public Text coinsLabel;
    public Text scoreLabel;
    public Text highScoreLabel;
    void Awake() {

        sharedInstance = this;    
    }

    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame){
            scoreLabel.text = playerController.sharedInstance.GetDistance().ToString("f0"); 
        }
    }
    public void updateHighScoreLabel(){
        if (GameManager.sharedInstance.currentGameState == GameState.inGame){
            highScoreLabel.text = PlayerPrefs.GetFloat("highscore",0).ToString("f0");
        }
    }
    public void updateCoinsLabel(){
        if (GameManager.sharedInstance.currentGameState == GameState.inGame){
            coinsLabel.text = GameManager.sharedInstance.collectedCoins.ToString();
        }
    }
    

}
