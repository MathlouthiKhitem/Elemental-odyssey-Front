using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections.Generic;

public class DeleteAcc : MonoBehaviour
{

       
       [SerializeField] private string authURL = "http://127.0.0.1:9090/user/DeleteAcc";
        
    public void OnDeleteAcclick()
    {

        StartCoroutine(TryDeleteAcc());
        

    }
    private IEnumerator TryDeleteAcc()
    {
       
        string UserNamePref = PlayerPrefs.GetString("UserNamePref"); 
     

       // JObject json = JObject.Parse(UserNamePref);
    //    Debug.Log("{{{{{{{{{{"+json)
       // JObject json = JObject.Parse($"{{\"UserName\": \"{UserNamePref}\"}}");
    //tring json1 = json.ToString(Newtonsoft.Json.Formatting.None);
       // Debug.Log("///////////////////////"+json);
       //string json1 = JsonConvert.SerializeObject(UserNamePref);
       WWWForm lll = new WWWForm();
        lll.AddField("UserName",UserNamePref);
        UnityWebRequest request = UnityWebRequest.Post(authURL,lll);
        var handler = request.SendWebRequest();
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
        if (request.result ==UnityWebRequest.Result.Success) 
        { 
           
            Debug.Log(request.downloadHandler.text);
        }
        else
         {
            Debug.Log("unable to connect");
        }
        yield return null;  
    }

}
