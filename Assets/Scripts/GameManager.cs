using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //게임 시작 및 오버 확인, 그 외 세부 사항 참조에 사용됨
    public static bool Game_Over;
    public static bool Game_Start;
    private bool flag = false;
    private bool object_enabled = false;

    //게임 내에서 이동하는 오브젝트(배경, 장애물, 플레이어)가 일괄적으로 사용하는 이동 속도 관련 변수들
    //기존 코드에선 Player, obstacle, background 코드에 분산되어 있었으나 static 변수를 이용해 단일화
    public static float speed;
    public float multiplier;

    //결과 및 시작 화면 UI 오브젝트(prefab)
    public GameObject resultScreen;

    //게임 최초 시작 시 Active 상태로 전환되어야 하는 오브젝트들
    //void Start에서 발동되는 함수들이 씬이 로드될 때가 아닌 게임이 실제 시작된 후 시작될 필요가 있음
    public GameObject player, battery, scoreboard, spawner;

    private void Start()
    {
        //기초적인 상태 확인용 변수들 초기화
        flag = false;
        object_enabled = false;
        speed = 3f;

        //게임 최초 시작 시 시작 확인 UI 생성
        if (!Game_Start)
        {
            var ResultScreen = Instantiate(resultScreen, gameObject.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
        }

    }
    void Update()
    {
        //게임 오버 시 게임 오버 확인 UI 생성
        if (Game_Over && !flag)
        {
            //게임 오버 상태에서 반복적인 호출을 방지하기 위해 2차 플래그를 사용
            flag = true;
            var ResultScreen = Instantiate(resultScreen, gameObject.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
            //Debug.Log("Game Over" + Battery_UI.battery_meter_value);
        }

        //'돌' 장애물에 충돌 시 감속
        if (CollisionManager.hit_rock)
            StartCoroutine(slowDown());

        //특정 함수들이 씬이 최초 로드되는 순간부터 작동하는 것을 방지
        if (Game_Start && !object_enabled)
        {
            //게임이 실제 시작된 후 enable
            enabled = true;
            player.SetActive(true);
            battery.SetActive(true);
            scoreboard.SetActive(true);
            spawner.SetActive(true);
        }
            
    }

    //'돌' 장애물에 충돌 시 3초간 감속
    private IEnumerator slowDown()
    {
        CollisionManager.hit_rock = false;
        speed /= multiplier; 
        yield return new WaitForSeconds(3f);
        speed *= multiplier;
    }
}
