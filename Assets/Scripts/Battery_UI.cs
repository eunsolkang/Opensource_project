using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery_UI : MonoBehaviour
{

    //배터리 UI 내 잔량 부분 이미지 및 비율 특정
    public Image battery_meter;
    public static float battery_meter_value;

    //잔량 변화가 적용되는 간격(시간), 해당 간격마다 자동적으로 감소하는 배터리의 양 특정
    public float downAmount;
    public float interval;

    private void Awake()
    {
        //게임 시작 시 배터리를 최대치로 초기화
        battery_meter_value = 1;
    }
    void Start()
    {
        //게임이 시작될 때 배터리 잔량이 감소하기 시작
        StartCoroutine(BatteryDown());
    }

    private void Update()
    {
        //배터리 잔량이 0 이하가 될 시 게임 오버
        if (battery_meter_value < 0) GameManager.Game_Over = true;
    }

    //interval초마다 배터리 잔량이 감소하고, 그 감소치가 실제 UI에 적용됨
    //Oil로 인해 배터리가 1(최대치) 이상이 될 시 1로 초기화
    private IEnumerator BatteryDown()
    {
        while (!GameManager.Game_Over)
        {
            if (battery_meter_value > 1) battery_meter_value = 1;
            battery_meter_value -= downAmount;
            battery_meter.fillAmount = battery_meter_value;
            yield return new WaitForSeconds(interval);
        }
        
    }
}
