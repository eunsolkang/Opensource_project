using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 뒤에 생길 경로 유니티 상에서 설정
    [SerializeField]
    private GameObject Trail;

    // 경로가 생길 위치 지정
    [SerializeField]
    private Transform TrailTransform;

    void Update()
    {
        // 게임 오버가 안되었다는 가정 하에
        if(!GameManager.Game_Over)
        {
            // 방향키 좌우를 입력함에 따라 좌우로 이동
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
            transform.position += moveTo * GameManager.speed * Time.deltaTime;

            TrailRoutine();
        }
        
    }

    // 플레이어 뒤에 경로 이미지가 계속 생성되게 설정
    void TrailRoutine(){
        Instantiate(Trail, TrailTransform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Trail").transform);
    }
    

}

