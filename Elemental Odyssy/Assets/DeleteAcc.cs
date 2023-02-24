using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DeleteAcc : MonoBehaviour
{
      
       [SerializeField] private string authURL = "http://127.0.0.1:9090/user/DeleteAcc/:UserName";
        
    public void OnDeleteAcclick()
    {

        StartCoroutine(TryDeleteAcc());
        

    }
    private IEnumerator TryDeleteAcc()
    {
        UnityWebRequest request = UnityWebRequest.Get(authURL);
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
             string UserNamePref = PlayerPrefs.GetString("UserNamePref");
            Debug.Log(request.downloadHandler.text);
        }
        else
         {
            Debug.Log("unable to connect");
        }
        yield return null;  
    }

}
