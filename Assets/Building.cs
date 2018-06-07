using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    private bool showModal = false;

    private List<Texture2D> images;

	// Use this for initialization
	void Start () {
        images = new List<Texture2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator OnMouseUp()
    {
        this.showModal = true;
        if (this.images.Count == 0)
        {
            yield return this.LoadImage("https://i.ebayimg.com/images/g/O6kAAOSw7Bda~Oak/s-l1600.jpg");
            yield return this.LoadImage("https://i.ebayimg.com/images/g/97QAAOSw7bla~Oak/s-l500.jpg");
            yield return this.LoadImage("https://i.ebayimg.com/images/g/3gUAAOSwXrBa~Oak/s-l500.jpg");
            yield return this.LoadImage("https://i.ebayimg.com/images/g/I4oAAOSwe~ha~Oak/s-l500.jpg");
        }
    }

	void OnGUI()
	{
        if (this.showModal)
        {
            GUI.ModalWindow(1, new Rect(0, 0, Screen.width , Screen.height), RenderStoreWindow, "eCity - Computer Store");
        }
	}

    private IEnumerator LoadImage(string url)
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            Debug.Log(url + " request done");
            this.images.Add(www.texture);
        }
    }

	// Make the contents of the window
	private void RenderStoreWindow(int windowID)
    {
        this.RenderEbayItems();
        if (GUI.Button(new Rect(Screen.width - 200, Screen.height - 100, 100, 50), "Close"))
        {
            this.showModal = false;
        }
    }

    private void RenderEbayItems() 
    {
        float x = 30f;
        float y = 20f;

        for (int i = 0; i < this.images.Count; i++)
        {
            var texture = this.images[i];
            GUI.DrawTexture(new Rect(x, y, 370, 320), texture);


            x += 400;
            if (x + 400 > Screen.width) 
            {
                x = 30f;
                y += 330;
            }
        }
    }
}
