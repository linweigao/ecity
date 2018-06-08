using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{

    public long baseValue = 10L;
    private System.Random random = new System.Random();
    public Text mytext = null;
    public Player player = null;
    public float refreshInterval = 1f;
    public bool isDaynamic = true;

    // Use this for initialization
    void Start()
    {
        if (isDaynamic)
        {
            StartCoroutine("GetCurrentCount");
        }
        else
        {
            mytext.text = "Apple";
            mytext.color = Color.white;
            mytext.transform.rotation = player.transform.rotation;
        }
    }

    private void Update()
    {
        if (!isDaynamic)
        {
            mytext.transform.rotation = player.transform.rotation;
        }
    }
    IEnumerator GetCurrentCount()
    {
        for (; baseValue < 5000;)
        {
            int tmp = random.Next(10);
            if (tmp % 5 < 2)
            {
                tmp *= -1;
            }
            baseValue += tmp;
            mytext.text = string.Format("{0}", baseValue < 0 ? 0 : baseValue);
            Color textColor;
            if (baseValue < 100)
            {
                textColor = Color.yellow;
            }
            else if (baseValue < 200)
            {
                textColor = Color.green;
            }
            else if (baseValue < 500)
            {
                textColor = Color.blue;
            }
            else
            {
                textColor = Color.red;
            }
            textColor.a = 0.7f;
            mytext.color = textColor;
            mytext.transform.rotation = player.transform.rotation;
            yield return new WaitForSeconds(refreshInterval + tmp / 10);
        }

        mytext.text = "5000+";
        mytext.color = new Color(0.5377f, 0.0684f, 0.0684f, 1);
        mytext.transform.rotation = player.transform.rotation;
        yield return new WaitForSeconds(refreshInterval * 10);
    }

}