using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Text

public class Spreadsheet2App_MainCamera : MonoBehaviour {

	protected GameObject MyLayerMenu {get;set;}
	protected SimpleJSON.JSONArray MyList {get;set;}

	// Use this for initialization
	void Start () {
		SetStart();
	}
	
	// Update is called once per frame
	void Update () {
		SetUpdate();
	}
	
	protected virtual void SetStart()
	{
		SetReset();
	}
	
	protected virtual void SetUpdate()
	{
	}
	
	protected virtual void SetReset()
	{
		Screen.orientation = ScreenOrientation.Portrait;
		gameObject.GetComponent<Camera>().orthographic = true;
		
		SetGameObjects();
		SetItems();

		StopAllCoroutines();
		StartCoroutine (SetListStart());
	}

	protected virtual void SetGameObjects()
	{
		if (MyLayerMenu == null)
		{
			MyLayerMenu = GameObject.Find (GetModuleName()+" Layer Menu");
		}
	}

	protected virtual string GetModuleName()
  	{
		string s;
		s = "Spreadsheet2App";
		return s;
	}

	protected virtual void SetItems()
	{
		GameObject aGo;
		Vector3 v3;
		Vector2 v2;

		if (MyLayerMenu != null)
		{
			aGo = MyLayerMenu;
			v3 = gameObject.transform.position;
			v3 = new Vector3(v3.x, v3.y, v3.z + 10.0f);
			aGo.transform.position = v3;

			aGo = MyLayerMenu.transform.Find ("Canvas/Panel Items").gameObject;
			v3 = aGo.GetComponent<RectTransform>().localScale;
			v3 = new Vector3(v3.x, v3.y * 0.5f, v3.z);
			aGo.GetComponent<RectTransform>().localScale = v3;

			v2 = aGo.GetComponent<RectTransform>().pivot;
			v2 = new Vector2(v2.x, 0.0f);
			aGo.GetComponent<RectTransform>().pivot = v2;

			aGo.GetComponent<ScrollRect>().movementType = ScrollRect.MovementType.Clamped;
			aGo.AddComponent<Mask>();
			aGo.GetComponent<ScrollRect>().content = aGo.transform.Find ("Canvas Items").gameObject.GetComponent<RectTransform>();
			aGo.GetComponent<ScrollRect>().verticalScrollbar = MyLayerMenu.transform.Find ("Canvas/Scrollbar").gameObject.GetComponent<Scrollbar>();

			aGo = MyLayerMenu.transform.Find ("Canvas/Panel Item").gameObject;
			v3 = aGo.GetComponent<RectTransform>().localScale;
			v3 = new Vector3(v3.x, v3.y * 0.5f, v3.z);
			aGo.GetComponent<RectTransform>().localScale = v3;

			v2 = aGo.GetComponent<RectTransform>().pivot;
			v2 = new Vector2(v2.x, 1.0f);
			aGo.GetComponent<RectTransform>().pivot = v2;
			
			aGo = MyLayerMenu.transform.Find ("Canvas/Panel Item/Image").gameObject;
			v3 = aGo.GetComponent<RectTransform>().localScale;
			v3 = new Vector3(v3.x, v3.y/aGo.transform.parent.GetComponent<RectTransform>().localScale.y, v3.z);
			aGo.GetComponent<RectTransform>().localScale = v3;

			v2 = aGo.GetComponent<RectTransform>().pivot;
			v2 = Vector2.one * 0.5f;
			aGo.GetComponent<RectTransform>().pivot = v2;

			aGo = MyLayerMenu.transform.Find ("Canvas/Panel Item/Text").gameObject;
			aGo.GetComponent<Text>().text = "";
			v3 = aGo.GetComponent<RectTransform>().localScale;
			v3 = new Vector3(v3.x, v3.y/aGo.transform.parent.GetComponent<RectTransform>().localScale.y, v3.z);
			aGo.GetComponent<RectTransform>().localScale = v3;

			v2 = aGo.GetComponent<RectTransform>().pivot;
			v2 = Vector2.one * 0.5f;
			aGo.GetComponent<RectTransform>().pivot = v2;

			aGo = MyLayerMenu.transform.Find ("Canvas/Scrollbar").gameObject;
			v2 = Vector2.one * 0.5f;
			v2 = new Vector2(1.0f, v2.y);
			aGo.GetComponent<RectTransform>().anchorMin = v2;
			v2 = Vector2.one * 0.5f;
			v2 = new Vector2(1.0f, v2.y);
			aGo.GetComponent<RectTransform>().anchorMax = v2;

			MyLayerMenu.transform.Find ("Canvas/Button").gameObject.SetActive(true);
			aGo = Instantiate (MyLayerMenu.transform.Find ("Canvas/Button").gameObject);
			MyLayerMenu.transform.Find ("Canvas/Button").gameObject.SetActive(false);
// ↻
			aGo.transform.Find ("Text").gameObject.GetComponent<Text>().text = "\u21bb";
			aGo.transform.SetParent (MyLayerMenu.transform.Find ("Canvas/Panel Item"));
			v2 = aGo.GetComponent<RectTransform>().sizeDelta;
			v2 = new Vector2(Mathf.Min (v2.x, v2.y), Mathf.Min (v2.x, v2.y));
			aGo.GetComponent<RectTransform>().sizeDelta = v2;
			v3 = aGo.GetComponent<RectTransform>().position;
			v3 = Vector3.zero;
			v3 = new Vector3(v3.x, v3.y, gameObject.GetComponent<Camera>().nearClipPlane);
			v3 = new Vector3(v3.x+((float)Screen.width*1.0f), v3.y+((float)Screen.height*1.0f), (aGo.transform.parent.gameObject.GetComponent<RectTransform>().position.z - 1.0f));
			v3 = new Vector3(v3.x+(aGo.GetComponent<RectTransform>().rect.width*-0.5f), v3.y+(aGo.GetComponent<RectTransform>().rect.height*-0.5f), v3.z);
			aGo.GetComponent<RectTransform>().position = v3;
			aGo.GetComponent<Button>().onClick.AddListener(delegate{Application.LoadLevel(Application.loadedLevelName);});
		}
	}

	protected IEnumerator SetListStart()
	{
		string aLink;
		WWW aWWW;
		string aResponse;
		SimpleJSON.JSONClass aJsonClass;

		aLink = "https://goo.gl/...ID...";
		aWWW = new WWW(aLink);
		yield return aWWW;

		if (aWWW.error == null)
		{
			aResponse = aWWW.text;
/*
 * Hard-coded JSON data feed example
 * 
 * {"version":"1.0","encoding":"UTF-8","feed":{"xmlns":"http://www.w3.org/2005/Atom","xmlns$openSearch":"http://a9.com/-/spec/opensearchrss/1.0/","xmlns$gsx":"http://schemas.google.com/spreadsheets/2006/extended","id":{"$t":"https://spreadsheets.google.com/feeds/list/.../od6/public/values"},"updated":{"$t":"2015-07-12T00:00:00.000Z"},"category":[{"scheme":"http://schemas.google.com/spreadsheets/2006","term":"http://schemas.google.com/spreadsheets/2006#list"}],"title":{"type":"text","$t":"Sheet1"},"link":[{"rel":"alternate","type":"application/atom+xml","href":"https://docs.google.com/spreadsheets/d/.../pubhtml"},{"rel":"http://schemas.google.com/g/2005#feed","type":"application/atom+xml","href":"https://spreadsheets.google.com/feeds/list/.../od6/public/values"},{"rel":"http://schemas.google.com/g/2005#post","type":"application/atom+xml","href":"https://spreadsheets.google.com/feeds/list/.../od6/public/values"},{"rel":"self","type":"application/atom+xml","href":"https://spreadsheets.google.com/feeds/list/.../od6/public/values?alt\u003djson"}],"author":[{"name":{"$t":"spreadsheet2app"},"email":{"$t":"spreadsheet2app@email.com"}}],"openSearch$totalResults":{"$t":"2"},"openSearch$startIndex":{"$t":"1"},"entry":[{"id":{"$t":"https://spreadsheets.google.com/feeds/list/.../od6/public/values/cokwr"},"updated":{"$t":"2015-07-12T00:00:00.000Z"},"category":[{"scheme":"http://schemas.google.com/spreadsheets/2006","term":"http://schemas.google.com/spreadsheets/2006#list"}],"title":{"type":"text","$t":"1"},"content":{"type":"text","$t":"title: Item One T, description: Item One D, imagelink: http://drive.google.com/uc?export\u003dview\u0026id\u003d__ID__\u0026, lastupdated: 7/13/2015"},"link":[{"rel":"self","type":"application/atom+xml","href":"https://spreadsheets.google.com/feeds/list/.../od6/public/values/cokwr"}],"gsx$id":{"$t":"1"},"gsx$title":{"$t":"Item One T"},"gsx$description":{"$t":"Item One D"},"gsx$imagelink":{"$t":"http://drive.google.com/uc?export\u003dview\u0026id\u003d__ID__\u0026"},"gsx$lastupdated":{"$t":"7/13/2015"}},{"id":{"$t":"https://spreadsheets.google.com/feeds/list/.../od6/public/values/cpzh4"},"updated":{"$t":"2015-07-12T00:00:00.000Z"},"category":[{"scheme":"http://schemas.google.com/spreadsheets/2006","term":"http://schemas.google.com/spreadsheets/2006#list"}],"title":{"type":"text","$t":"2"},"content":{"type":"text","$t":"title: Item Two T, description: Item Two D, imagelink: http://drive.google.com/uc?export\u003dview\u0026id\u003d__ID__\u0026, lastupdated: 7/13/2015"},"link":[{"rel":"self","type":"application/atom+xml","href":"https://spreadsheets.google.com/feeds/list/.../od6/public/values/cpzh4"}],"gsx$id":{"$t":"2"},"gsx$title":{"$t":"Item Two T"},"gsx$description":{"$t":"Item Two D"},"gsx$imagelink":{"$t":"http://drive.google.com/uc?export\u003dview\u0026id\u003d__ID__\u0026"},"gsx$lastupdated":{"$t":"7/13/2015"}}]}}
 * 
 */
			aJsonClass = (SimpleJSON.JSONNode.Parse (""+aResponse) as SimpleJSON.JSONClass);
			MyList = aJsonClass["feed"]["entry"].AsArray;
			SetButtons();
		}
		else
		{
			aResponse = aWWW.error;
			MyList = (SimpleJSON.JSONNode.Parse ("[]") as SimpleJSON.JSONArray);
		}
		aWWW.Dispose();
		yield return null;
	}

	protected virtual void SetButtons()
	{
		GameObject aGo;
		GameObject aClone;
		Vector3 v3;
		Vector2 v2;
		float aOffset;

		if (MyLayerMenu != null)
		{
			aGo = MyLayerMenu.transform.Find ("Canvas/Panel Items/Canvas Items").gameObject;
			v2 = aGo.GetComponent<RectTransform>().sizeDelta;
			MyLayerMenu.transform.Find ("Canvas/Button").gameObject.SetActive(true);
			v2 = new Vector2(v2.x, (MyList.Count * MyLayerMenu.transform.Find ("Canvas/Button").gameObject.GetComponent<RectTransform>().sizeDelta.y));
			MyLayerMenu.transform.Find ("Canvas/Button").gameObject.SetActive(false);

			v2 = new Vector2(v2.x, v2.y/aGo.transform.parent.gameObject.GetComponent<RectTransform>().localScale.y);
			aGo.GetComponent<RectTransform>().sizeDelta = v2;
			v3 = aGo.GetComponent<RectTransform>().localPosition;
			v3 = new Vector3(0.0f, v3.y-(MyList.Count * v2.y), v3.z);
			aGo.GetComponent<RectTransform>().localPosition = v3;

			aGo = MyLayerMenu;

			for(int i=0; i<MyList.Count; i++)
			{
				GameObject aGameObject;

				aGo.transform.Find ("Canvas/Button").gameObject.SetActive(true);
				aClone = Instantiate (aGo.transform.Find ("Canvas/Button").gameObject);
				aGo.transform.Find ("Canvas/Button").gameObject.SetActive(false);
				aClone.transform.Find ("Text").gameObject.GetComponent<Text>().text = ""+MyList[i]["gsx$id"]["$t"].Value;
				aClone.transform.SetParent (aGo.transform.Find ("Canvas/Panel Items/Canvas Items"));

				v2 = aClone.GetComponent<RectTransform>().sizeDelta;
				v3 = aClone.transform.parent.gameObject.GetComponent<RectTransform>().position;
				v3 = new Vector3(v3.x, v3.y, v3.z - 1.0f);
				v3 = new Vector3(v3.x, v3.y+(i*-v2.y), v3.z);
				v3 = new Vector3(v3.x, v3.y+(v2.y*-0.5f), v3.z);
				aOffset = (MyLayerMenu.transform.Find ("Canvas/Panel Items/Canvas Items").gameObject.GetComponent<RectTransform>().sizeDelta.y*0.5f)*MyLayerMenu.transform.Find ("Canvas/Panel Items/Canvas Items").parent.gameObject.GetComponent<RectTransform>().localScale.y;
				v3 = new Vector3(v3.x, v3.y+aOffset, v3.z);
				aClone.GetComponent<RectTransform>().position = v3;

				aGameObject = aClone;
				aClone.GetComponent<Button>().onClick.AddListener(delegate{StartCoroutine(SetItemClickStart(aGameObject));});
			}
		}
	}

	protected IEnumerator SetItemClickStart(GameObject aGameObject)
	{
		GameObject aGo;
		WWW aWWW;
		Vector2 v2;
		Rect aRect;
		string aImageLink;
		Texture2D aTexture2D;

		if (MyLayerMenu != null)
		{
			aGo = MyLayerMenu.transform.Find ("Canvas/Panel Item/Image").gameObject;
			aGo.GetComponent<Image>().sprite = new Sprite();

			aGo = MyLayerMenu.transform.Find ("Canvas/Panel Item/Text").gameObject;
			aGo.GetComponent<Text>().text = MyList[GetItemIdIndex(aGameObject.transform.Find ("Text").GetComponent<Text>().text)]["gsx$title"]["$t"].Value;

			aImageLink = MyList[GetItemIdIndex(aGameObject.transform.Find ("Text").GetComponent<Text>().text)]["gsx$imagelink"]["$t"].Value;

			aWWW = new WWW(aImageLink);
			yield return aWWW;

			aGo = MyLayerMenu.transform.Find ("Canvas/Panel Item/Image").gameObject;
			v2 = Vector2.one * 0.5f;
			v2 = new Vector2(v2.x, v2.y);
			aRect = aGo.GetComponent<RectTransform>().rect;

			aRect = new Rect(0.0f, 0.0f, (float)aWWW.texture.width, (float)aWWW.texture.height);

			aTexture2D = new Texture2D((int)aRect.width, (int)aRect.height, TextureFormat.ARGB32, false);

			aTexture2D.SetPixels (aWWW.texture.GetPixels());
			aTexture2D.Apply();

			aGo.GetComponent<Image>().sprite = Sprite.Create(aTexture2D, aRect, v2);
		}
		yield return null;
	}

	protected virtual int GetItemIdIndex(string aId)
	{
		int aIndex;
		aIndex = -1;

		for(int i=0; i<MyList.Count; i++)
		{
			if (MyList[i]["gsx$id"]["$t"].Value.Trim ().Equals (aId))
			{
				aIndex = i;
				break;
			}
		}

		return aIndex;
	}
}
