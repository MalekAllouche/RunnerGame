using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinS;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinS.Play();
            ScorePoints.coinCount += 1;
            this.gameObject.SetActive(false);
        }

    }
}
