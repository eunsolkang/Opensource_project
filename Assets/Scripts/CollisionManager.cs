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

    public GameObject alarmText;
    private TMP_Text alarmText_text;
    private Vector3 playerPosition;

    private void Awake()
    {
       alarmText_text = alarmText.GetComponent<TMP_Text>();
       playerPosition = gameObject.transform.position;
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
            AlarmTextShow("+"+coinScore.ToString(),false);
            Destroy(collision.gameObject);
        }

        else if (collision.tag == "Enemy")
        {
            Battery_UI.battery_meter_value -= enemyDmg;
            score_UI.score -= enemyDownScore;
            AlarmTextShow("-"+enemyDownScore.ToString(), true);
            Destroy(collision.gameObject);
        }
    }

    private void AlarmTextShow(string number, bool enemy)
    {
        var alarmtext = Instantiate(alarmText, gameObject.transform.position, Quaternion.identity,GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
        alarmtext.GetComponent<TMP_Text>().text = number.ToString();
        if (enemy) 
            alarmtext.GetComponent<TMP_Text>().color = Color.red;
        else
            alarmtext.GetComponent<TMP_Text>().color = Color.white;
    }
}
