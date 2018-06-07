using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    static Dictionary<int, Item> items;

    static Building() {
        items = new Dictionary<int, Item>();
        items.Add(1, new Item(1, "https://www.ebay.com/ulk/p/ASUS-90pd02e1-m00750-AMD-Quad-Core-Ryzen-7-1700gry-G11dfdbr7gtx107/2165326262?iid=142811454515",
                              new string[] {
            "https://i.ebayimg.com/images/g/O6kAAOSw7Bda~Oak/s-l1600.jpg",
            "https://i.ebayimg.com/images/g/97QAAOSw7bla~Oak/s-l500.jpg",
            "https://i.ebayimg.com/images/g/3gUAAOSwXrBa~Oak/s-l500.jpg",
            "https://i.ebayimg.com/images/g/I4oAAOSwe~ha~Oak/s-l500.jpg",
        }));

        items.Add(10, new Item(10, "https://www.ebay.com/itm/SEA-RAY-SUNDANCER-300-2005-Trailer-not-incluided/113035852653?hash=item1a51763b6d:g:J~8AAOSwgTJbAaJi",
                               new string[] {
            "https://i.ebayimg.com/images/g/J~8AAOSwgTJbAaJi/s-l500.jpg",
            "https://i.ebayimg.com/images/g/SLgAAOSwA4BbAaJl/s-l500.jpg",
            "https://i.ebayimg.com/images/g/jNcAAOSwEARbAaJv/s-l500.jpg",
            "https://i.ebayimg.com/images/g/EjEAAOSwrCZbAaJz/s-l500.jpg",
            "https://i.ebayimg.com/images/g/QwIAAOSwuyNbAaJ1/s-l500.jpg"
        }));
    }
    public int itemId;
    private Item item;

    private bool showModal = false;

	// Use this for initialization
	void Start () {
        this.item = items[this.itemId];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator OnMouseUp()
    {
        this.showModal = true;
        if (this.item.Textures.Count == 0)
        {
            foreach (var imageUrl in this.item.ImageUrls)
            {
                yield return this.LoadImage(imageUrl);
            }
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
            this.item.Textures.Add(www.texture);
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

        for (int i = 0; i < this.item.Textures.Count; i++)
        {
            var texture = this.item.Textures[i];
            if (GUI.Button(new Rect(x, y, 370, 320), texture)) {
                Application.OpenURL(this.item.ItemUrl);
            }


            x += 400;
            if (x + 400 > Screen.width) 
            {
                x = 30f;
                y += 330;
            }
        }
    }
}

public class Item
{
    private int itemId;
    private string[] imageUrls;
    private string itemUrl;

            public Item(int itemId, string itemUrl, string[] imageUrls)
    {
        this.itemId = itemId;
        this.imageUrls = imageUrls;
        this.itemUrl = itemUrl;
        this.Textures = new List<Texture2D>();
    }

    public string ItemUrl 
    {
        get 
        {
            return this.itemUrl;  
        }
    }

    public List<Texture2D> Textures
    {
        get;
        private set;
    }

    public string[] ImageUrls 
    {
        get {
            return this.imageUrls;
        }
    }
}
