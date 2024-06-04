using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public float oilAddValue;
    public int coinScore;
    public float enemyDmg;
    public int enemyDownScore;

    //public GameObject alarmText;
   // private TMP_Text alarmText_text;
    //public Vector3 playerPosition;

    private void Awake()
    {
       // alarmText_text = alarmText.GetComponent<TMP_Text>();
        //playerPosition = gameObject.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Oil")
        {
            Battery_UI.battery_meter_value += oilAddValue;
            Destroy(collision.gameObject);

        }

        else if (collision.tag == "Coin")
        {
            score_UI.score += coinScore;
           //AlarmTextShow("+"+coinScore.ToString());
            Destroy(collision.gameObject);
        }

        else if (collision.tag == "Enemy")
        {
            Battery_UI.battery_meter_value -= enemyDmg;
            score_UI.score -= enemyDownScore;
            //AlarmTextShow("-"+enemyDownScore.ToString());
            Destroy(collision.gameObject);
        }
    }

   /* private void AlarmTextShow(string number)
    {
        alarmText = Instantiate(alarmText, gameObject.transform.position, Quaternion.identity,GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
        alarmText.GetComponent<TMP_Text>().text = number.ToString();
    }*/
}
