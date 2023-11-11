using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedReducer2 : MonoBehaviour
{
    public float reducedSpeed = 0.05f;
    public float slowDuration = 3.0f;
    private float originalSpeed;
    private bool isPlayerSlowed = false;

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
