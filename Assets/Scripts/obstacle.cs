using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField]

    private float maxY = 6;
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Game_Over)
        {
            transform.position += Vector3.up * GameManager.speed * Time.deltaTime;
            if (transform.position.y > maxY)
            {
                Destroy(gameObject);
            }
        }

    }
}
