using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private PlayerMove playerMoveScript;

    private void Start()
    {
       
        playerMoveScript = player.GetComponent<PlayerMove>();
    }

    public void Lose()
    {

        
        playerMoveScript.enabled = false;

        StartCoroutine(ResetLevelAfterDelay(3f)); 
    }

    private IEnumerator ResetLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayerMove.tapToStart = false;
        ScorePoints.coinCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

