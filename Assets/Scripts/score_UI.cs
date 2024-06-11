using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class score_UI : MonoBehaviour
{

    //������ �� ������ �߰��� ������ ���
    public static float score = 0;
    public float multiplier;

    //�ΰ��� UI�� ǥ�õǴ� ���� �ؽ�Ʈ
    public TMP_Text scoreText;

    private void Awake()
    {
        //������ ���� �� ������ 0���� �ʱ�ȭ
        score = 0;
    }
    void Start()
    {
        //������ ���۵� �� ������ �ڿ������� ����ϱ� ����
        StartCoroutine(scoreAdd());
    }


    //������ ���� ���� ���� 0.1�ʸ��� �÷��̾��� �ӵ� * �����ŭ ������ �߰���
    private IEnumerator scoreAdd()
    {
        while (!GameManager.Game_Over && GameManager.Game_Start)
        {
            score += (GameManager.speed*multiplier);
            scoreText.text = ((int)score).ToString();
            yield return new WaitForSeconds(0.1f);
        }
        

    }
}
