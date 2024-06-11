using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    //'돌' 장애물 충돌 여부 판단용 변수
    public static bool hit_rock;

    //'기름'에 충돌 시 회복될 배터리
    //'동전'에 충돌 시 추가될 점수
    //'물'에 충돌 시 감소할 배터리
    //'물'과 '돌'에 충돌 시 감소될 점수
    public float oilAddValue;
    public int coinScore;
    public float enemyDmg;
    public int enemyDownScore;

    //'기름'과 '물', '돌'에 충돌 시 표시되는 점수 변동 알림 텍스트용 변수들 
    public GameObject alarmText;
    private TMP_Text alarmText_text;
    private Vector3 playerPosition;

    private void Awake()
    {
        //게임 시작 전 점수 알림용 텍스트 특정, 텍스트 생성 위치, 돌 충돌 여부 초기화
       alarmText_text = alarmText.GetComponent<TMP_Text>();
       playerPosition = gameObject.transform.position;
        hit_rock = false;
    }
    
    //다른 오브젝트와 충돌 시
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //게임이 진행되는 중이라면
        if (!GameManager.Game_Over)
        {
            //해당 오브젝트가 '기름'일 시 배터리 잔량 추가 후 충돌한 오브젝트 파괴
            if (collision.tag == "Oil")
            {
                Battery_UI.battery_meter_value += oilAddValue;
                Destroy(collision.gameObject);

            }

            //해당 오브젝트가 '동전'일 시 점수 추가 후 충돌한 오브젝트 파괴
            else if (collision.tag == "Coin")
            {
                score_UI.score += coinScore;
                AlarmTextShow("+" + coinScore.ToString(), false);
                Destroy(collision.gameObject);
            }

            //해당 오브젝트가 '두더지'일 시 게임 오버
            else if (collision.tag == "Enemy")
            {
                GameManager.Game_Over = true;
            }

            //해당 오브젝트가 '물'과 '돌'일 시 둘 다 점수를 감소시키므로 통합
            else if (collision.tag == "Water" || collision.tag == "Rock")
            {
                //충돌 시 점수 감소
                score_UI.score -= enemyDownScore;
                AlarmTextShow("-" + enemyDownScore.ToString(), true);

                //충돌한 오브젝트가 '물'일 시 배터리 잔량 감소
                if (collision.tag == "Water")
                {
                    Battery_UI.battery_meter_value -= enemyDmg;
                }

                //충돌한 오브젝트가 '돌'일 시 특정 함수 작동(GameManager.slowdown())
                else if (collision.tag == "Rock")
                {
                    hit_rock = true;
                }

                //충돌한 오브젝트 파괴
                Destroy(collision.gameObject);

            }
        }
    }

    //'동전', '물', '돌' 충돌 시 나타나는 점수 추가/감소 알림용 텍스트 표시
    //number 변수로 변동하는 점수를 나타내고 enemy 변수로 장애물 여부 판단
    //캐릭터의 충돌 당시 위치에 텍스트를 생성한다
    //장애물일 시 붉은 글씨(감소), 동전일 시 흰 글씨(추가)로 나타난다
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
