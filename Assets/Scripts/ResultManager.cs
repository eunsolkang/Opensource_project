using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class ResultManager : MonoBehaviour
{
    private Vector3 targetPos;
    public float speed;
    public int dif;

    public TMP_Text mainText, subText1, subText2;
    private bool moveFinished = false;

    public string[] StartText, OverText;

    private void Awake()
    {
        targetPos = Vector3.zero;
    }
    void Start()
    {
        moveFinished = false;

        if (GameManager.Game_Over)
        {
            mainText.text = OverText[0];
            subText1.text = "Score: " + ((int)score_UI.score).ToString();
            subText2.text = OverText[1];
        }

        else
        {
            mainText.text = StartText[0];
            subText1.text = " ";
            subText2.text = StartText[1];
        }
        
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

        if (GameManager.Game_Over)
        {
            GameManager.Game_Over = false;
            SceneManager.LoadScene("main");
        }

        else
        {
            GameManager.Game_Start = true;
            Destroy(gameObject);
        }
            
        
    }

    private IEnumerator moveDown()
    {
        targetPos.y = -dif;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        yield return new WaitUntil(()=>transform.position == targetPos);
    }
}
