using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class alarmtext_delete : MonoBehaviour
{
    private TMP_Text alarmText_text;
    private Color alarmText_color;
    void Start()
    {
        alarmText_text = gameObject.GetComponent<TMP_Text>();
        StartCoroutine(fadeText());
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
        
    }

    private IEnumerator fadeText()
    {
        while (alarmText_text.alpha > 0)
        {
            alarmText_text.alpha -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(gameObject);
    }

}
