using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class score_UI : MonoBehaviour
{

    public static float score = 0;
    public float multiplier;

    public TMP_Text scoreText;

    private void Awake()
    {
        score = 0;
    }
    void Start()
    {
        StartCoroutine(scoreAdd());
    }


    private IEnumerator scoreAdd()
    {
        while (!GameManager.Game_Over)
        {
            score += (GameManager.speed*multiplier);
            scoreText.text = ((int)score).ToString();
            yield return new WaitForSeconds(0.1f);
        }
        

    }
}
