using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery_UI : MonoBehaviour
{

    public Image battery_meter;
    public static float battery_meter_value;

    public float downAmount;
    public float interval;

    private void Awake()
    {
        battery_meter_value = 1;
    }
    void Start()
    {
        StartCoroutine(BatteryDown());
    }

    private void Update()
    {
        if (battery_meter_value < 0) GameManager.Game_Over = true;
    }

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
