using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class ResultManager : MonoBehaviour
{
    //�ش� UI�� �̵��� ��ġ, �̵� �ӵ�, �����Ǳ� �� �̵��� ��ġ���� �Ÿ�
    private Vector3 targetPos;
    public float speed;
    public int dif;

    //UI �� �ؽ�Ʈ Ư��
    public TMP_Text mainText, subText1, subText2;

    //UI �̵� �Ϸ� Ȯ�ο� �÷���
    private bool moveFinished = false;

    //UI�� ǥ�õ� �ؽ�Ʈ ����Ʈ
    //���� ���� ���� �ÿ� ���� ���� �÷� ����
    public string[] StartText, OverText;

    private void Awake()
    {
        //���� ���� �� ȭ�� �߾����� �̵��ؾ� ��
        targetPos = Vector3.zero;
    }
    void Start()
    {
        //������ ���� '�̵��� ������ ����' ���¿��� ��
        moveFinished = false;

        //���� ���� �ÿ� ���� �� ���� �ؽ�Ʈ�� ǥ��
        //���� ���� ����
        //���� ���� ����� ����
        //Ŭ���� ���� ������� �� ����
        if (GameManager.Game_Over)
        {
            mainText.text = OverText[0];
            subText1.text = "Score: " + ((int)score_UI.score).ToString();
            subText2.text = OverText[1];
        }

        //���� ���� ���� �ÿ� ���� �� ���� �ؽ�Ʈ�� ǥ��
        //���� ���� ����
        //���� ���� �ÿ� ������ �����Ƿ� ���� ǥ��
        //Ŭ���� ���� ������ �� ����
        else
        {
            mainText.text = StartText[0];
            subText1.text = " ";
            subText2.text = StartText[1];
        }
        
    }

    void Update()
    {
        //������ ��ġ���� �̵�
        if(transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        //��ġ�� ���� �� ���������� �˸�
        else moveFinished = true;

        //��ġ�� �����߰�, Ŭ�� �� Reset�ڷ�ƾ �۵�
        if(Input.GetMouseButtonDown(0) && moveFinished)
        {
           StartCoroutine(Reset());
        }
         
    }

    //ȭ�鿡�� ������ �ʴ� ��ġ�� �̵�
    //�� �� ������ ���͸� �ܷ��� �ʱ�ȭ
    //���� ���� Ȥ�� ���� ���� ���� ���ο� ���� ���� �ٽ� �ε��ϰų�, ������ ������
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

    //�̵��ؾ� �� ��ġ(targetPos)�� ��ġ�� ȭ�鿡 ������ �ʴ� ��ġ�� ������ �� �̵�
    private IEnumerator moveDown()
    {
        targetPos.y = -dif;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        yield return new WaitUntil(()=>transform.position == targetPos);
    }
}
