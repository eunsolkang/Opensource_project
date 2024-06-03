using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private float[] arrPosx = {-7f, -5f, -3f, -1f, 1f, 3f, 5f, 7f};

    [SerializeField]
    private float SpawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {   
        StartEnemyRoutine();
    }

    void StartEnemyRoutine(){
        StartCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine() {
        yield return new WaitForSeconds(3f);

        while (true){ 
            for (int i = 0; i < Random.Range(0, 8); i++){
                float posx = Random.Range(0, arrPosx.Length);
                int index = Random.Range(0, enemies.Length);
                SpawnEnemy(posx, index);
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
