using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private float[] arrPosx = {-7f, -5f, -3f, -1f, 1f, 3f, 5f, 7f};

    [SerializeField]
    private float SpawnInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {   
        StartEnemyRoutine();
    }

    void StartEnemyRoutine(){
        StartCoroutine("EnemyRoutine");
    }

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

    void SpawnEnemy(float posx, int index)
    {
        Vector3 spawnPos = new Vector3(posx, transform.position.y, transform.position.z);
        Instantiate(enemies[index], spawnPos, Quaternion.identity);
    }
}
