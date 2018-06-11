using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkMsg : MonoBehaviour {

    private bool showMsg;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp()
	{
        this.showMsg = true;
	}

	private void OnGUI()
	{
        if (showMsg && GUI.Button(new Rect(Screen.width - 300, 100, 200, 50), "Mark sent you a voice message"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
	}
}
