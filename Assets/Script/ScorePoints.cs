using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePoints : MonoBehaviour
{

    public static int coinCount;
    public GameObject ScoreC;

    void Update()
    {

        ScoreC.GetComponent<TMPro.TextMeshProUGUI>().text = "" + coinCount;

    }
}
