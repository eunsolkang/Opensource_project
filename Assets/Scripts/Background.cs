using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Game_Over && GameManager.Game_Start)
               transform.position += Vector3.up * GameManager.speed * Time.deltaTime;

    }

}
