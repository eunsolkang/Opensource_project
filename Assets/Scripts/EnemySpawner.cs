using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{   
    // 유니티 상에서 생성할 장애물들 설정
    [SerializeField]
    private GameObject[] enemies;
    // 장애물들이 생성될 x 좌표 8개 설정
    private float[] arrPosx = {-7f, -5f, -3f, -1f, 1f, 3f, 5f, 7f};

    // 유니티 상에서 장애물들이 생성될 시간 간격 설정
    [SerializeField]
    private float SpawnInterval = 2f;
    // 시작 시에 StartEnemyRoutine() 실행
    void Start()
    {   
        StartEnemyRoutine();
    }

    // StartEnemyRoutine 정의
    void StartEnemyRoutine(){
        // EnemyRoutine 실행
        StartCoroutine("EnemyRoutine");
    }
    // Enemyroutine 생성기
    IEnumerator EnemyRoutine() {
        yield return new WaitForSeconds(2f);
        // 적 무한 생성 반복
        while (!GameManager.Game_Over){ 
            // 같은 곳에서의 중복 생성 확인
            int[] flag = {0, 0, 0, 0, 0, 0, 0, 0, 0};
            // 최소 3개에서 최대 6개의 적 생성
            for (int i = 0; i < Random.Range(2, 7); i++){
                int posx = Random.Range(0, arrPosx.Length);
                while (flag[posx] == 1){
                    posx = Random.Range(0, arrPosx.Length);
                }
                flag[posx] = 1;
                int index = Random.Range(0, enemies.Length);
                SpawnEnemy(arrPosx[posx], index);
            }

            yield return new WaitForSeconds(SpawnInterval);
        }
    }

    // 여러 장애물 중 index번호의 장애물을 posx에 생성
    void SpawnEnemy(float posx, int index)
    {
        Vector3 spawnPos = new Vector3(posx, transform.position.y, transform.position.z);
        Instantiate(enemies[index], spawnPos, Quaternion.identity, GameObject.FindGameObjectWithTag("Obstacle").transform);
    }
}
