using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCount : MonoBehaviour
{
    public GameObject CD3;
    public GameObject CD2;
    public GameObject CD1;
    public GameObject CDGO;
    public GameObject player;

    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Space pressed");   
            StartCoroutine(CountSequence());        
        }
        
    }
    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(0.5f);
        CD3.SetActive(true);
        yield return new WaitForSeconds(1);
        CD2.SetActive(true);
        yield return new WaitForSeconds(1);
        CD1.SetActive(true);
        yield return new WaitForSeconds(1);
        CDGO.SetActive(true);
        player.GetComponent<Animator>().SetBool("RunStart", true);
        PlayerMove.tapToStart = true;
    }

}
