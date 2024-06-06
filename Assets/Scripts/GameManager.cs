using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool Game_Over;

    public GameObject resultScreen;

    void Update()
    {
        if (Battery_UI.battery_meter_value <= 0 && !Game_Over)
        {
            Game_Over = true;
            var ResultScreen = Instantiate(resultScreen, gameObject.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
            //Debug.Log("Game Over" + Battery_UI.battery_meter_value);
        }
            
    }
}
