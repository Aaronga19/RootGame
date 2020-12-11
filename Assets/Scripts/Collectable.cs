using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    bool IsCollected = false;

    void ShowCoin(){
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<CircleCollider2D>().enabled = true;

    }

    void HideCoin(){
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
    }

    void CollectCoin(){
        IsCollected = true;
        HideCoin();
        // notificar al manager que ha recogido una moneda
        GameManager.sharedInstance.CollectCoin();

    }
    void OnTriggerEnter2D(Collider2D otherCollider) {
        if(otherCollider.tag == "Player"){
            CollectCoin();
        }
    }

}
