using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevel : MonoBehaviour
{
    public GameObject Animation;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {           
            Debug.Log("Triggered by: " + other.name);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<PlayerMove>().enabled = false;
            Animation.GetComponent<Animator>().Play("Dance");
            StartCoroutine(GoToNextSceneAfterDelay(3f)); 
        }
        else
        {
            Debug.Log("Triggered by something else: " + other.gameObject.name);
        }
        
    }

    IEnumerator GoToNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayerMove.tapToStart = false;
        ScorePoints.coinCount = 0;
        SceneManager.LoadScene(1);
    }

}
