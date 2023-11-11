using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject Player;
    public GameObject Animation;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Triggered by: " + other.name);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<PlayerMove>().enabled = false;
            Animation.GetComponent<Animator>().Play("Stumble Backwards");
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.Lose();
            }
        }
        else
        {
            Debug.Log("Triggered by something else: " + other.gameObject.name);
        }
    }


}
