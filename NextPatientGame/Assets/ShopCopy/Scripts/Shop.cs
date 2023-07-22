using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
	#region Singlton:Shop

	public static Shop Instance;
	public Jokers jokers;
	void Awake ()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy (gameObject);
	}

	#endregion

	[System.Serializable] public class ShopItem
	{
		public Sprite Image;
		public int Price;
		public int shopItemId;
		public bool IsPurchased = false;

        public int purchaseCount = 0;
        public string ToString => "Item Price: " + Price + " Has " + purchaseCount + " of them.";
    }

	public List<ShopItem> ShopItemsList;
	[SerializeField] Animator NoCoinsAnim;
 

	[SerializeField] GameObject ItemTemplate;
	GameObject g;
	[SerializeField] Transform ShopScrollView;

    //my
	[SerializeField] GameObject ShopObject;
    Button buyBtn;

	void Start ()
	{
		for(int i = 0; i < ShopItemsList.Count; i++)
		{
			jokers.PurchaseJoker(ShopItemsList[i]);
        }
		

		int len = ShopItemsList.Count;
		for (int i = 0; i < len; i++) {
			g = Instantiate (ItemTemplate, ShopScrollView);
			g.transform.GetChild (0).GetComponent <Image> ().sprite = ShopItemsList [i].Image;
			g.transform.GetChild (1).GetChild (0).GetComponent <Text> ().text = ShopItemsList [i].Price.ToString ();
			buyBtn = g.transform.GetChild (2).GetComponent <Button> ();
			if (ShopItemsList [i].IsPurchased) {
				UpdateBuyButton(i, ShopItemsList[i].purchaseCount);
			}
			buyBtn.AddEventListener (i, OnShopItemBtnClicked);
		}
	}

	void OnShopItemBtnClicked (int itemIndex)
	{
		if (Gold.Instance.HasEnoughCoins(ShopItemsList[itemIndex].Price))
		{
			Gold.Instance.UseCoins(ShopItemsList[itemIndex].Price);
            Gold.Instance.UpdateAllCoinsUIText();
            Debug.Log("Joker at index: " + itemIndex + " purchased!!");
			
			//ShopItemsList[itemIndex].purchaseCount++;
			jokers.purchasedJokers[itemIndex].purchaseCount++;
			
            ShopItemsList[itemIndex].IsPurchased = true;
            UpdateBuyButton(itemIndex, ShopItemsList[itemIndex].purchaseCount);
        }
        else
        {
            NoCoinsAnim.SetTrigger("NoCoins");
            Debug.Log("You don't have enough coins!!");
        }
    }

	void UpdateBuyButton(int itemIndex, int itemCount)
	{
        buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
        buyBtn.transform.GetChild(0).GetComponent<Text>().text = "BUY / " + itemCount;
	}

	/*---------------------Open & Close shop--------------------------*/
	
	/*
	public void OpenShop ()
	{
        ShopObject.SetActive(true);
    }

	public void CloseShop ()
	{
        ShopObject.SetActive(false);
    }
	*/
}

