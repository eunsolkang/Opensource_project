using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class score_UI : MonoBehaviour
{

    //점수와 매 프레임 추가될 점수의 배수
    public static float score = 0;
    public float multiplier;

    //인게임 UI에 표시되는 점수 텍스트
    public TMP_Text scoreText;

    private void Awake()
    {
        //게임이 시작 시 점수를 0으로 초기화
        score = 0;
    }
    void Start()
    {
        //게임이 시작될 때 점수가 자연적으로 상승하기 시작
        StartCoroutine(scoreAdd());
    }


    //게임이 진행 중인 동안 0.1초마다 플레이어의 속도 * 배수만큼 점수가 추가됨
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
