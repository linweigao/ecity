using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var player = this.gameObject;
        var r = new System.Random();

        int move = r.Next(10);

        if (move == 1)
        {
            player.transform.Rotate(0, 10f, 0);
        }
        else if (move == 2)
        {
            player.transform.Rotate(0, -10f, 0);
        }
        else if (move < 5)
        {
            player.transform.Translate(0, 0, 0.02f);
        }
	}
}
