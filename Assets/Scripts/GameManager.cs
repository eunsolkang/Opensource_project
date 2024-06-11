using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool Game_Over;
    private bool flag = false;

    public static float speed;
    public float multiplier;

    public GameObject resultScreen;

    private void Start()
    {
        flag = false;
        speed = 3f;
    }
    void Update()
    {
        if (Game_Over && !flag)
        {
            flag = true;
            var ResultScreen = Instantiate(resultScreen, gameObject.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
            //Debug.Log("Game Over" + Battery_UI.battery_meter_value);
        }

        if (CollisionManager.hit_rock)
            StartCoroutine(slowDown());
            
    }

    private IEnumerator slowDown()
    {
        CollisionManager.hit_rock = false;
        speed /= multiplier; 
        yield return new WaitForSeconds(3f);
        speed *= multiplier;
    }
}
