using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // 게임오버되지 않을 시
        if(!GameManager.Game_Over)
                // 맵은 계속해서 위로 이동
               transform.position += Vector3.up * GameManager.speed * Time.deltaTime;

    }

}
