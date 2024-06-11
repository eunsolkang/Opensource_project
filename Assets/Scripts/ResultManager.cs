using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class ResultManager : MonoBehaviour
{
    private Vector3 targetPos;
    public float speed;
    public int dif;

    public TMP_Text scoretext;
    private bool moveFinished = false;
    private void Awake()
    {
        targetPos = Vector3.zero;
    }
    void Start()
    {
        scoretext.text = "Score: " + ((int)score_UI.score).ToString();
    }

    void Update()
    {
        if(transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        else moveFinished = true;

        if(Input.GetMouseButtonDown(0) && moveFinished)
        {
           
           StartCoroutine(Reset());
        }
         
    }

    private IEnumerator Reset()
    {
        yield return StartCoroutine(moveDown());
        score_UI.score = 0;
        Battery_UI.battery_meter_value = 1;
        GameManager.Game_Over = false;
        SceneManager.LoadScene("main");
    }

    private IEnumerator moveDown()
    {
        targetPos.y = -dif;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        yield return new WaitUntil(()=>transform.position == targetPos);
    }
}
