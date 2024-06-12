using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery_UI : MonoBehaviour
{

    //���͸� UI �� �ܷ� �κ� �̹��� �� ���� Ư��
    public Image battery_meter;
    public static float battery_meter_value;

    //�ܷ� ��ȭ�� ����Ǵ� ����(�ð�), �ش� ���ݸ��� �ڵ������� �����ϴ� ���͸��� �� Ư��
    public float downAmount;
    public float interval;

    private void Awake()
    {
        //���� ���� �� ���͸��� �ִ�ġ�� �ʱ�ȭ
        battery_meter_value = 1;
    }
    void Start()
    {
        //������ ���۵� �� ���͸� �ܷ��� �����ϱ� ����
        StartCoroutine(BatteryDown());
    }

    private void Update()
    {
        //���͸� �ܷ��� 0 ���ϰ� �� �� ���� ����
        if (battery_meter_value < 0) GameManager.Game_Over = true;
    }

    //interval�ʸ��� ���͸� �ܷ��� �����ϰ�, �� ����ġ�� ���� UI�� �����
    //Oil�� ���� ���͸��� 1(�ִ�ġ) �̻��� �� �� 1�� �ʱ�ȭ
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
