using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Collections.Generic;
using TMPro;

public static class ButtonExtension
{
	public static void AddEventListener<T> (this Button button, T param, Action<T> OnClick)
	{
		button.onClick.AddListener (delegate() {
			OnClick (param);
		});
	}
}
public class FriendsList : MonoBehaviour
{
	[Serializable]
	public struct Game
	{
			public string FirstName;
			public string Image ;
		public Sprite Imageicon;
		
	}
	[SerializeField] private Text userName;
	[SerializeField] private Image profile ;
	
	//[SerializeField] private TextMeshProUGUI userImage;

	Game[] allGames;
	[SerializeField] Sprite defaultIcon;
    [Obsolete]
    void Start()
	{
		//fetch data from Json
		StartCoroutine (GetGames());
	}
	void DrawUI ()
	{
		
		GameObject buttonTemplate = transform.GetChild (0).gameObject;
		GameObject background =  GameObject.Find("background");
		GameObject child = background.transform.GetChild(0).gameObject;
		GameObject g;
		int N = allGames.Length;
		for (int i = 0; i < N; i++) {
			
		g = Instantiate (buttonTemplate, transform);
		userName.text = allGames[i].FirstName;
		profile.sprite = allGames[i].Imageicon;
		//g.transform.GetChild (0).GetComponent <Text> ().text = "yooooo";
		//allGames[i].FirstName;
		//g.transform.GetChild (1).GetComponent <Image> ().sprite = allGames [i].Imageicon;
			g.GetComponent <Button> ().AddEventListener (i, ItemClicked);
		}
			
		Destroy(transform.GetChild (1).gameObject);
	}
	void ItemClicked (int itemIndex)
	{
		Debug.Log ("name " + allGames [itemIndex].FirstName);
	}
    //***************************************************
    [Obsolete]
    IEnumerator GetGames ()
	{
		string url = "http://localhost:9090/friends/showfriends/63fa277f119aa6e98cd936b5";
		UnityWebRequest request = UnityWebRequest.Get (url);
		request.chunkedTransfer = false;
		yield return request.Send();
		if (request.isNetworkError) {
		} else {
			if (request.isDone) {
				 allGames = JsonHelper.GetArray<Game>(request.downloadHandler.text);
				for (int i = 0; i < allGames.Length; i++) {
			allGames = JsonConvert.DeserializeObject<List<Game>>(request.downloadHandler.text).ToArray() ;
				Debug.Log ("..........." + allGames[i].FirstName);
				 string FirstName =allGames[i].FirstName;
            PlayerPrefs.SetString("FirstName",FirstName);
					Debug.Log ("FirstName" + FirstName);
            PlayerPrefs.Save();
				}
				StartCoroutine (GetGamesIcones ());
			}
		}
	}
    [Obsolete]
    IEnumerator GetGamesIcones ()
	{
		for (int i = 0; i < allGames.Length; i++) {
			WWW w = new WWW (allGames [i].Image);
			yield return w;
			if (w.error != null) {
				allGames [i].Imageicon = defaultIcon;
			} else {
				if (w.isDone) {
					Texture2D tx = w.texture;
					allGames [i].Imageicon = Sprite.Create (tx, new Rect (0f, 0f, tx.width, tx.height), Vector2.zero, 10f);
				}
			}
		}
		DrawUI ();	
	}

}