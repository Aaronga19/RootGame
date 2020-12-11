using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ViewGameOver : MonoBehaviour
{
    public static ViewGameOver sharedInstance;
    public Text coinsLabel;
    public Text scoreLabel;
    // Start is called before the first frame update
    void Awake() {
        sharedInstance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void updateCoins(){
        if (GameManager.sharedInstance.currentGameState == GameState.gameOver){
            coinsLabel.text = GameManager.sharedInstance.collectedCoins.ToString();
        }
    }
    public void updateScore(){
        if (GameManager.sharedInstance.currentGameState == GameState.gameOver){
            scoreLabel.text = playerController.sharedInstance.GetDistance().ToString("f0"); 
        }  
    }
}