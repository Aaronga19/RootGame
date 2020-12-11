using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour
{
    public static playerController sharedInstance;
    public float jumpForce = 6.0f;
    public float runningSpeed = 3.0f;
    private Rigidbody2D rigidBody;
    public LayerMask groundLayerMask;
    public Animator animator;
    
    private Vector3 startPosition;
    private string highscoreKey = "highscore";


    void Awake() {
        animator.SetBool("isAlive", true);
        sharedInstance = this;
        rigidBody =  GetComponent<Rigidbody2D>();
        startPosition = this.transform.position;
    }


    // Start is called before the first frame update
    public void StartGame()
    {
        animator.SetBool("isAlive", true);        
        this.transform.position = startPosition;
        rigidBody.velocity = new Vector2(0,0);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame){
            //if (Input.GetButtonDown("space")) {
            if (Input.GetMouseButtonDown(0)) {
                //Debug.Log("Boton izquierdo del raton pulsado");
                jump();
            }
        }
        /*
        if (distanceTravelled % 20 == 0){
            runningSpeed = runningSpeed + 1.5f;
        }
        */
        animator.SetBool("isGrounded",isOnTheFloor());
    }
    void FixedUpdate() {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame){
            if (rigidBody.velocity.x < runningSpeed){
                rigidBody.velocity = new Vector2 (runningSpeed, rigidBody.velocity.y);
            }
        }
    }

    void jump(){
        if(isOnTheFloor()){
            rigidBody.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
    }
    bool isOnTheFloor(){
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, groundLayerMask.value)){
            return true;
        }else{
            return false;
        }
    }
    public void KillPlayer(){
        GameManager.sharedInstance.GameOver();
        animator.SetBool("isAlive", false);
        if (PlayerPrefs.GetFloat(highscoreKey, 0)< this.GetDistance()){
            PlayerPrefs.SetFloat(highscoreKey, this.GetDistance());

        }

    }
    public float GetDistance(){
        float distanceTravelled = Vector2.Distance(new Vector2(startPosition.x, 0),
        new Vector2(this.transform.position.x,0));
        
        return distanceTravelled;
    }
}
