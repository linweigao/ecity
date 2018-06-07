using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private bool go = false;
    private bool back = false;
    private bool turnRight = false;
    private bool turnLeft = false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        var player = this.gameObject;
        if (Input.touchCount > 0) 
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary) 
            {
                if (touch.position.x < 100) 
                {
                    this.turnLeft = true;
                }
                else if (touch.position.x > Screen.width - 100)
                {
                    this.turnRight = true;
                }
                else
                {
                    this.go = true;
                }

            }
            else if (touch.phase == TouchPhase.Ended)
            {
                this.turnRight = false;
                this.turnLeft = false;
                this.go = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            this.go = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            this.go = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.back = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.back = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            this.turnRight = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.turnRight = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.turnLeft = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.turnLeft = false;
        }

        if (this.turnRight) {
            player.transform.Rotate(0, 1f, 0);
        }
        else if (this.turnLeft)
        {
            player.transform.Rotate(0, -1f, 0);
        }

        if (this.go) {
            player.transform.Translate(0, 0, 0.1f);
        }
        else if(this.back) // go over write the back
        {
            player.transform.Translate(0, 0, -0.1f);
        }

	}

    void OnGUI()
    {
        //string text = this.go ? "Stop" : "Go";

        //// Fixed Layout
        //if (GUI.Button(new Rect(Screen.width - 50 , Screen.height - 25, 40, 20), text)) {
        //    this.go = !this.go;
        //}
    }
}
