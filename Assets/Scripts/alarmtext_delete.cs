using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class alarmtext_delete : MonoBehaviour
{
    //��ֹ� �� ���� �浹 �� ��Ÿ���� ���� �߰�/���� �˸��� �ؽ�Ʈ Ư�� �� ���� ������ ���� Color ���� Ư��
    private TMP_Text alarmText_text;
    private Color alarmText_color;
    void Start()
    {
        //�ؽ�Ʈ�� ��Ÿ���� ���ÿ� ������� ����
        alarmText_text = gameObject.GetComponent<TMP_Text>();
        StartCoroutine(fadeText());
    }

    void Update()
    {
        //���� ������ �����δ�
        transform.Translate(Vector3.up * Time.deltaTime);
        
    }

    //������ 0(������ ����)�� �� ������ ������ ���������ٰ� 0�� �Ǹ� �ı��ȴ�
    private IEnumerator fadeText()
    {
        while (alarmText_text.alpha > 0)
        {
            alarmText_text.alpha -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(gameObject);
    }

}
