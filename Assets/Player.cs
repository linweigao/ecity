using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private bool go = false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (this.go) {
            var player = this.gameObject;
            var position = player.transform.position;
            player.transform.position = new Vector3(position.x, position.y, position.z + 0.1f);
        }

	}

    void OnGUI()
    {
        string text = this.go ? "Stop" : "Go";

        // Fixed Layout
        if (GUI.Button(new Rect(Screen.width - 50 , Screen.height - 25, 40, 20), text)) {
            this.go = !this.go;
        }
    }
}
