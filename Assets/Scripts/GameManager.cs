using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool Game_Over;
    void Start()
    {
        
    }

    void Update()
    {
        if (Battery_UI.battery_meter_value <= 0)
        {
            Game_Over = true;
            Debug.Log("Game Over" + Battery_UI.battery_meter_value);
        }
            
    }
}
