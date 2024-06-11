using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool Game_Over;
    public static bool Game_Start;
    private bool flag = false;
    private bool object_enabled = false;

    public static float speed;
    public float multiplier;

    public GameObject resultScreen;

    public GameObject player, battery, scoreboard, spawner;

    private void Start()
    {
        flag = false;
        object_enabled = false;
        speed = 3f;

        if (!Game_Start)
        {
            var ResultScreen = Instantiate(resultScreen, gameObject.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
        }

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

        if (Game_Start && !object_enabled)
        {
            enabled = true;
            player.SetActive(true);
            battery.SetActive(true);
            scoreboard.SetActive(true);
            spawner.SetActive(true);
        }
            
    }

    private IEnumerator slowDown()
    {
        CollisionManager.hit_rock = false;
        speed /= multiplier; 
        yield return new WaitForSeconds(3f);
        speed *= multiplier;
    }
}
