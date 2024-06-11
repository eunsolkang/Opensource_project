using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    //'��' ��ֹ� �浹 ���� �Ǵܿ� ����
    public static bool hit_rock;

    //'�⸧'�� �浹 �� ȸ���� ���͸�
    //'����'�� �浹 �� �߰��� ����
    //'��'�� �浹 �� ������ ���͸�
    //'��'�� '��'�� �浹 �� ���ҵ� ����
    public float oilAddValue;
    public int coinScore;
    public float enemyDmg;
    public int enemyDownScore;

    //'�⸧'�� '��', '��'�� �浹 �� ǥ�õǴ� ���� ���� �˸� �ؽ�Ʈ�� ������ 
    public GameObject alarmText;
    private TMP_Text alarmText_text;
    private Vector3 playerPosition;

    private void Awake()
    {
        //���� ���� �� ���� �˸��� �ؽ�Ʈ Ư��, �ؽ�Ʈ ���� ��ġ, �� �浹 ���� �ʱ�ȭ
       alarmText_text = alarmText.GetComponent<TMP_Text>();
       playerPosition = gameObject.transform.position;
        hit_rock = false;
    }
    
    //�ٸ� ������Ʈ�� �浹 ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //������ ����Ǵ� ���̶��
        if (!GameManager.Game_Over)
        {
            //�ش� ������Ʈ�� '�⸧'�� �� ���͸� �ܷ� �߰� �� �浹�� ������Ʈ �ı�
            if (collision.tag == "Oil")
            {
                Battery_UI.battery_meter_value += oilAddValue;
                Destroy(collision.gameObject);

            }

            //�ش� ������Ʈ�� '����'�� �� ���� �߰� �� �浹�� ������Ʈ �ı�
            else if (collision.tag == "Coin")
            {
                score_UI.score += coinScore;
                AlarmTextShow("+" + coinScore.ToString(), false);
                Destroy(collision.gameObject);
            }

            //�ش� ������Ʈ�� '�δ���'�� �� ���� ����
            else if (collision.tag == "Enemy")
            {
                GameManager.Game_Over = true;
            }

            //�ش� ������Ʈ�� '��'�� '��'�� �� �� �� ������ ���ҽ�Ű�Ƿ� ����
            else if (collision.tag == "Water" || collision.tag == "Rock")
            {
                //�浹 �� ���� ����
                score_UI.score -= enemyDownScore;
                AlarmTextShow("-" + enemyDownScore.ToString(), true);

                //�浹�� ������Ʈ�� '��'�� �� ���͸� �ܷ� ����
                if (collision.tag == "Water")
                {
                    Battery_UI.battery_meter_value -= enemyDmg;
                }

                //�浹�� ������Ʈ�� '��'�� �� Ư�� �Լ� �۵�(GameManager.slowdown())
                else if (collision.tag == "Rock")
                {
                    hit_rock = true;
                }

                //�浹�� ������Ʈ �ı�
                Destroy(collision.gameObject);

            }
        }
    }

    //'����', '��', '��' �浹 �� ��Ÿ���� ���� �߰�/���� �˸��� �ؽ�Ʈ ǥ��
    //number ������ �����ϴ� ������ ��Ÿ���� enemy ������ ��ֹ� ���� �Ǵ�
    //ĳ������ �浹 ��� ��ġ�� �ؽ�Ʈ�� �����Ѵ�
    //��ֹ��� �� ���� �۾�(����), ������ �� �� �۾�(�߰�)�� ��Ÿ����
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
