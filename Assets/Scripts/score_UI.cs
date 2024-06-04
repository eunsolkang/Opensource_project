using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class score_UI : MonoBehaviour
{

    public static float score = 0;
    private float speed;
    public float multiplier;

    public TMP_Text scoreText;

    public Player digger;

    private void Awake()
    {
        score = 0;
        speed = digger.speed;
    }
    void Start()
    {
        StartCoroutine(scoreAdd());
    }


    private IEnumerator scoreAdd()
    {
        while (true)
        {
            score += (speed*multiplier);
            scoreText.text = score.ToString();
            yield return new WaitForSeconds(0.1f);
        }
        

    }
}
