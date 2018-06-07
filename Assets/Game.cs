using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    private string[] names = new string[] { "Max", "John", "Micheal", "Kenny", "Sarah" };
    private int stayCount = 0;
    private int random;


    void OnGUI()
    {
        // Random display people login
        if (this.stayCount > 0) 
        {
            string message = string.Format("{0} has just joined eCity.", names[this.random]);
            GUI.Label(new Rect(Screen.width - 200, 0, 300, 20), message);
            this.stayCount--;
        }
        else 
        {
            var random = (int)(Random.value * 100);
            if (random < 5)
            {
                this.random = random;
                this.stayCount = 100;
            }
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
