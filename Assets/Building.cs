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


        items.Add(2, new Item(2, "https://www.ebay.com/itm/NEW-Apple-2017-iPad-9-7-Retina-Display-128GB-A9-Wifi-Touch-ID/292504593948?epid=235057941",
                      new string[] {
            "https://i.ebayimg.com/images/g/7Y4AAOSwdcZa9EAc/s-l400.jpg",
            "https://i.ebayimg.com/images/g/inEAAOSwvGlajgac/s-l500.jpg",
            "https://i.ebayimg.com/images/g/D~4AAOSwsW9Y2Ibc/s-l500.jpg",
            "https://i.ebayimg.com/images/g/xIAAAOSwYtla0LK4/s-l400.jpg",
            "https://i.ebayimg.com/images/g/BDEAAOSwUlxaKFZY/s-l400.jpg",
            "https://i.ebayimg.com/images/g/ybsAAOSwldRaKFZU/s-l400.jpg",
            "https://i.ebayimg.com/images/g/cc4AAOSw6WNax6lj/s-l400.jpg",
            "https://i.ebayimg.com/images/g/1EgAAOSwdoVZhccI/s-l400.jpg",
            "https://i.ebayimg.com/images/g/iBQAAOSwr7tZhccK/s-l400.jpg"
        }));

        items.Add(10, new Item(10, "https://www.ebay.com/itm/Crownline-Speedboat-with-Cuddy/163078140247",
                               new string[] {
            "https://i.ebayimg.com/images/g/CoIAAOSw48dbEuc1/s-l400.jpg",
            "https://i.ebayimg.com/images/g/zlsAAOSwYK1bEuc2/s-l400.jpg",
            "https://i.ebayimg.com/images/g/uQAAAOSwirFbEuc3/s-l400.jpg",
            "https://i.ebayimg.com/images/g/FTMAAOSwdhlbEuc7/s-l400.jpg"
        }));

        items.Add(20, new Item(20, "https://www.ebay.com/sch/i.html?_from=R40&_nkw=tesla&_sacat=0&_fosrp=1",
                               new string[] {
            "https://i.ebayimg.com/images/g/FaYAAOSwshJa-G-7/s-l400.jpg",
            "https://i.ebayimg.com/images/g/Ut8AAOSwi4pa-G-8/s-l400.jpg",
            "https://i.ebayimg.com/images/g/SMUAAOSwPGpbBZ6I/s-l500.jpg",
            "https://i.ebayimg.com/images/g/K2kAAOSwrptbBZ6L/s-l500.jpg",
            "https://i.ebayimg.com/images/g/YJMAAOSwQb1bGWhc/s-l400.jpg",
            "https://i.ebayimg.com/images/g/tFYAAOSwjyhaCRji/s-l500.jpg"
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
