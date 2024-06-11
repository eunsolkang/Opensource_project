using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class alarmtext_delete : MonoBehaviour
{
    //장애물 및 동전 충돌 시 나타나는 점수 추가/감소 알림용 텍스트 특정 및 투명도 조절을 위한 Color 변수 특정
    private TMP_Text alarmText_text;
    private Color alarmText_color;
    void Start()
    {
        //텍스트가 나타남과 동시에 사라지기 시작
        alarmText_text = gameObject.GetComponent<TMP_Text>();
        StartCoroutine(fadeText());
    }

    void Update()
    {
        //위로 서서히 움직인다
        transform.Translate(Vector3.up * Time.deltaTime);
        
    }

    //투명도가 0(투명한 상태)가 될 때까지 서서히 투명해지다가 0이 되면 파괴된다
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
