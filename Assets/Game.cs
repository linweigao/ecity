using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    private string[] names = new string[] { "Max", "John", "Micheal", "Kenny", "Sarah" };
    private int stayCount = 0;
    private string friendName;


    void OnGUI()
    {
        // Random display people login
        if (this.stayCount > 0) 
        {
            string message = string.Format("{0} has just joined eCity.", this.friendName);
            GUI.Label(new Rect(Screen.width - 300, 10, 300, 100), message);
            this.stayCount--;
        }
        else 
        {
            var random = (int)(Random.value * 100);
            if (random < 5)
            {
                this.friendName = names[random] + (int)(Random.value * 1000);
                this.stayCount = 300;
            }
        }

        if (GUI.Button(new Rect(Screen.width - 300, 100, 200, 50), "Mark sent you a voice message"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
}

	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
