using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    // 장애물 코드

    [SerializeField]
    private float maxY = 6;
    // Update is called once per frame
    void Update()
    {   
        // 게임오버가 되지 않았을 떄
        if (!GameManager.Game_Over)
        {
            // 장애물은 위로 이동
            transform.position += Vector3.up * GameManager.speed * Time.deltaTime;
            // 화면 밖을 나가면 장애물 삭제
            if (transform.position.y > maxY)
            {
                Destroy(gameObject);
            }
        }

    }
}
