using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour {

    private long dynamicValue = 20L;
    private System.Random random = new System.Random();
    public Text mytext = null;
    public Player player = null;

	// Use this for initialization
	void Start () {
        StartCoroutine("GetCurrentCount");
    }
	 
    IEnumerator GetCurrentCount()
    {
        for (; ; )
        {
            int tmp = random.Next(10);
            if(tmp % 5 == 1)
            {
                tmp *= -1;
            }
            dynamicValue += tmp;
            mytext.text = string.Format("{0}", dynamicValue);
            if(dynamicValue > 100)
            {
                mytext.color = Color.green;
            }
            if(dynamicValue > 200)
            {
                mytext.color = Color.red;
            }
            if(dynamicValue > 500)
            {
                mytext.color = Color.black;
            }
            mytext.transform.rotation = player.transform.rotation;
            yield return new WaitForSeconds(0.5f);
        }
    }

}
