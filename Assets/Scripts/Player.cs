using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject Trail;
    [SerializeField]
    private Transform TrailTransform;


    void Update()
    {
    
        if(!GameManager.Game_Over)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
            transform.position += moveTo * GameManager.speed * Time.deltaTime;

            TrailRoutine();
        }
        
    }

    void TrailRoutine(){
        Instantiate(Trail, TrailTransform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Trail").transform);
    }
    

}
