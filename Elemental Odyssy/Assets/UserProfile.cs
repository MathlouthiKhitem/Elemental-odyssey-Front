using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserProfile : MonoBehaviour
{
    public RawImage ProfileImage;
    public RawImage RankIcon;
    [SerializeField] private string getoneURL = "http://localhost:9090/user/getOne";
    [SerializeField] private TextMeshProUGUI ProfileName;
    [SerializeField] private TextMeshProUGUI ProfileBalance;
    [SerializeField] private TextMeshProUGUI ProfileRank;

    public void OnBackButtonClick() 
    {
        SceneManager.GetSceneByBuildIndex(0);

    }

    IEnumerator Start()
    {
        
            
            
            WWWForm LoginForm = new WWWForm();
            LoginForm.AddField("Email", "elemental@email.com");
            UnityWebRequest request = UnityWebRequest.Post(getoneURL, LoginForm);
            var handler = request.SendWebRequest();
            Debug.Log(handler);
            float startTime = 0.0f;
            while (!handler.isDone)
            {
                startTime += Time.deltaTime;
                if (startTime > 10.0f)
                {
                    break;
                }
                yield return null;
            }
           
            if (request.result == UnityWebRequest.Result.Success)
            {
            Debug.Log(request.downloadHandler.text);
            GameAccount returnedAccountinfo = JsonUtility.FromJson<GameAccount>(request.downloadHandler.text);
            ProfileName.text = returnedAccountinfo.UserName;
            ProfileRank.text = returnedAccountinfo.Rank;
            
            WWW www = new WWW(returnedAccountinfo.Image);
            yield return www;
            Texture2D LoadProfileImage = www.texture;
            ProfileImage.texture= LoadProfileImage;
            RankIcon.texture= LoadProfileImage;
            Debug.Log(request.downloadHandler.text);
            //playerPrefs userName 
            string UserNamePref =ProfileName.text;
            PlayerPrefs.SetString("UserNamePref",UserNamePref);
            PlayerPrefs.Save();
            }
            else
            {
                Debug.Log("unable to connect");
            }
            yield return null;
        }
    }


