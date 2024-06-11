using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //���� ���� �� ���� Ȯ��, �� �� ���� ���� ������ ����
    public static bool Game_Over;
    public static bool Game_Start;
    private bool flag = false;
    private bool object_enabled = false;

    //���� ������ �̵��ϴ� ������Ʈ(���, ��ֹ�, �÷��̾�)�� �ϰ������� ����ϴ� �̵� �ӵ� ���� ������
    //���� �ڵ忡�� Player, obstacle, background �ڵ忡 �л�Ǿ� �־����� static ������ �̿��� ����ȭ
    public static float speed;
    public float multiplier;

    //��� �� ���� ȭ�� UI ������Ʈ(prefab)
    public GameObject resultScreen;

    //���� ���� ���� �� Active ���·� ��ȯ�Ǿ�� �ϴ� ������Ʈ��
    //void Start���� �ߵ��Ǵ� �Լ����� ���� �ε�� ���� �ƴ� ������ ���� ���۵� �� ���۵� �ʿ䰡 ����
    public GameObject player, battery, scoreboard, spawner;

    private void Start()
    {
        //�������� ���� Ȯ�ο� ������ �ʱ�ȭ
        flag = false;
        object_enabled = false;
        speed = 3f;

        //���� ���� ���� �� ���� Ȯ�� UI ����
        if (!Game_Start)
        {
            var ResultScreen = Instantiate(resultScreen, gameObject.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
        }

    }
    void Update()
    {
        //���� ���� �� ���� ���� Ȯ�� UI ����
        if (Game_Over && !flag)
        {
            //���� ���� ���¿��� �ݺ����� ȣ���� �����ϱ� ���� 2�� �÷��׸� ���
            flag = true;
            var ResultScreen = Instantiate(resultScreen, gameObject.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
            //Debug.Log("Game Over" + Battery_UI.battery_meter_value);
        }

        //'��' ��ֹ��� �浹 �� ����
        if (CollisionManager.hit_rock)
            StartCoroutine(slowDown());

        //Ư�� �Լ����� ���� ���� �ε�Ǵ� �������� �۵��ϴ� ���� ����
        if (Game_Start && !object_enabled)
        {
            //������ ���� ���۵� �� enable
            enabled = true;
            player.SetActive(true);
            battery.SetActive(true);
            scoreboard.SetActive(true);
            spawner.SetActive(true);
        }
            
    }

    //'��' ��ֹ��� �浹 �� 3�ʰ� ����
    private IEnumerator slowDown()
    {
        CollisionManager.hit_rock = false;
        speed /= multiplier; 
        yield return new WaitForSeconds(3f);
        speed *= multiplier;
    }
}
