using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedReducer : MonoBehaviour
{
    public float reducedSpeed = 0.05f; 
    public float slowDuration = 4f;  
    private float originalSpeed;
    private static bool isPlayerSlowed = false;
    public GameObject Animation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMove playerMove = other.GetComponent<PlayerMove>();
            if (playerMove != null)
            {
                if (!isPlayerSlowed)
                {
                    
                    isPlayerSlowed = true;
                    originalSpeed = playerMove.speed;
                    playerMove.SetSpeed(reducedSpeed);
                    StartCoroutine(ResetSpeedAfterDelay(playerMove));
                }
                else
                {

                    StopCoroutine(ResetSpeedAfterDelay(playerMove)); 
                    other.GetComponent<PlayerMove>().enabled = false;
                    Animation.GetComponent<Animator>().Play("Stumble Backwards");
                    GameManager gameManager = FindObjectOfType<GameManager>();
                    if (gameManager != null)
                    {
                        gameManager.Lose();
                    }
                }
            }
        }
    }

    private IEnumerator ResetSpeedAfterDelay(PlayerMove playerMove)
    {
        yield return new WaitForSeconds(slowDuration);
        if (playerMove != null)
        {
            playerMove.SetSpeed(originalSpeed);
            isPlayerSlowed = false;
        }
    }
}
