using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class Deletefriends : MonoBehaviour
{
    [SerializeField] private string authURL = "http://127.0.0.1:9090/friends/Deletefriends";
    
    public void OnDeletefriendsClick()
    {

        StartCoroutine(TryDeletefriends());
        

    }
    private IEnumerator TryDeletefriends()
    {

      
//          string EmailPlayerPrefs = PlayerPrefs.GetString("Email");
//              Debug.Log("////////  "+ EmailPlayerPrefs);
   
       
//          string url = "http://localhost:9090/friends/getUserId/"+EmailPlayerPrefs;
//         UnityWebRequest request = UnityWebRequest.Get (url);
// 		request.chunkedTransfer = false;
// 		yield return request.Send();
       
//         if (request.isNetworkError) {
//             Debug.Log("fail");
//            StartCoroutine( add(request.downloadHandler.text.Substring(1, request.downloadHandler.text.Length - 2)));
// 		} else {
// 			if (request.isDone) {
//              StartCoroutine( add(request.downloadHandler.text.Substring(1, request.downloadHandler.text.Length - 2)));
// 			}
// 		}
// 				}
//         IEnumerator add(string body){
//             string FirstName=  PlayerPrefs.GetString("FirstName");
//    Debug.Log("////////  "+ FirstName);
//      Debug.Log("{{{{{{}}}}}}  "+ body);
   
//         string url1 = "http://127.0.0.1:9090/friends/Deletefriends";
// 		 WWWForm LoginForm = new WWWForm();
//         LoginForm.AddField("FirstName",FirstName);
//         LoginForm.AddField("user",body);
//          UnityWebRequest request2 = UnityWebRequest.Post(url1,LoginForm);
//      //   var handler2 = request2.SendWebRequest();
//         yield return request2.Send();
//          if (request2.isDone) 
//          {
//                Debug.Log("sucess"+request2.downloadHandler.text);
//              Application.LoadLevel(Application.loadedLevel);
//              // SSTools.ShowMessage("Friend added sucessfully !" , SSTools.Position.bottom , SSTools.Time.twoSecond);
//          }

//          else
//           {
//             Debug.Log("unable to connect");
//        }
            
				
		

        //  string EmailPlayerPrefs = PlayerPrefs.GetString("Email");
        //      Debug.Log("////////  "+ EmailPlayerPrefs);
   string FirstName=  PlayerPrefs.GetString("FirstName");
   Debug.Log("////////  "+ FirstName);
   
        WWWForm LoginForm = new WWWForm();
        LoginForm.AddField("user","63fa277f119aa6e98cd936b5");
        LoginForm.AddField("FirstName",FirstName);
       
        
        UnityWebRequest request = UnityWebRequest.Post(authURL,LoginForm);
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
        if (request.result == UnityWebRequest.Result.Success) 
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

