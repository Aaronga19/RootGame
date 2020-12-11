using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState{
    menu,
    inGame,
    gameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public GameState currentGameState = GameState.menu;
    public Canvas menuCanvas;
    public Canvas gameCanvas;
    public Canvas gameOverCanvas;
    public int collectedCoins = 0;



    void Awake() {
        sharedInstance = this;        
    }
    public void Start(){
        currentGameState = GameState.menu;
        menuCanvas.enabled = true;
        gameCanvas.enabled = false;
        gameOverCanvas.enabled = false;

    }
    void Update() {
        /*if (Input.GetButtonDown("s")){
            //currentGameState = GameState.inGame;
            StartGame();
        }*/
    }
    public void StartGame(){
        playerController.sharedInstance.StartGame();
        LevelGenerator.sharedInstance.GenerateInitialBlocks();
        ChangeGameState(GameState.inGame);
        ViewInGame.sharedInstance.updateHighScoreLabel();
    }
// Start is called before the first frame update
    public void GameOver()
    {
        LevelGenerator.sharedInstance.RemoveAllBlocks();
        ChangeGameState(GameState.gameOver);
        ViewGameOver.sharedInstance.updateCoins();
        ViewGameOver.sharedInstance.updateScore();

    }
// Lo llamamos cuando el jugador decide ir al menu principal
    public void BackToMainMenu(){
        ChangeGameState(GameState.menu);
    }

    void ChangeGameState(GameState newGameState){
        if  (newGameState == GameState.menu){
            menuCanvas.enabled = true;
            gameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            //La escene de Unity debera mostrar el menu principal

        }else if (newGameState == GameState.inGame){
            menuCanvas.enabled = false;
            gameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
            // Configurar escena en juego

        }else if (newGameState == GameState.gameOver){
            menuCanvas.enabled = false;
            gameCanvas.enabled = false;  
            gameOverCanvas.enabled = true;
            // Configurar escena game over
        }
        
        currentGameState = newGameState;
    }
    public void CollectCoin(){
        collectedCoins++;
        //Debug.Log("Monedas recogidas: " + collectedCoins);
        ViewInGame.sharedInstance.updateCoinsLabel();
    }
   
}
