using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class ResultManager : MonoBehaviour
{
    //해당 UI가 이동할 위치, 이동 속도, 삭제되기 전 이동할 위치와의 거리
    private Vector3 targetPos;
    public float speed;
    public int dif;

    //UI 내 텍스트 특정
    public TMP_Text mainText, subText1, subText2;

    //UI 이동 완료 확인용 플래그
    private bool moveFinished = false;

    //UI에 표시될 텍스트 리스트
    //각각 게임 시작 시와 게임 오버 시로 구분
    public string[] StartText, OverText;

    private void Awake()
    {
        //최초 생성 시 화면 중앙으로 이동해야 함
        targetPos = Vector3.zero;
    }
    void Start()
    {
        //생성될 때는 '이동이 끝나지 않은' 상태여야 함
        moveFinished = false;

        //게임 오버 시엔 다음 세 가지 텍스트를 표시
        //게임 오버 선언
        //게임 오버 당시의 점수
        //클릭을 통해 재시작할 수 있음
        if (GameManager.Game_Over)
        {
            mainText.text = OverText[0];
            subText1.text = "Score: " + ((int)score_UI.score).ToString();
            subText2.text = OverText[1];
        }

        //게임 최초 시작 시엔 다음 세 가지 텍스트를 표시
        //게임 시작 선언
        //게임 시작 시엔 점수가 없으므로 공란 표기
        //클릭을 통해 시작할 수 있음
        else
        {
            mainText.text = StartText[0];
            subText1.text = " ";
            subText2.text = StartText[1];
        }
        
    }

    void Update()
    {
        //지정된 위치까지 이동
        if(transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        //위치에 도착 시 도착했음을 알림
        else moveFinished = true;

        //위치에 도착했고, 클릭 시 Reset코루틴 작동
        if(Input.GetMouseButtonDown(0) && moveFinished)
        {
           StartCoroutine(Reset());
        }
         
    }

    //화면에서 보이지 않는 위치로 이동
    //그 후 점수와 배터리 잔량을 초기화
    //게임 오버 혹은 게임 최초 시작 여부에 따라 씬을 다시 로드하거나, 게임을 시작함
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

    //이동해야 할 위치(targetPos)의 위치를 화면에 보이지 않는 위치로 재조정 후 이동
    private IEnumerator moveDown()
    {
        targetPos.y = -dif;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        yield return new WaitUntil(()=>transform.position == targetPos);
    }
}
