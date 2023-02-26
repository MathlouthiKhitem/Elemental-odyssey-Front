using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;


public class fORGETAMAN : MonoBehaviour
{
    [SerializeField] private string authURL = "http://127.0.0.1:9090/user/forgot";
    [SerializeField] private TMPro.TMP_InputField EmailInputField;
    
    
    public void OnForgetClick()
    {

        StartCoroutine(TryForget());
        

    }
    private IEnumerator TryForget()
    {
        string Email = EmailInputField.text;
        Debug.Log(Email);
        WWWForm LoginForm = new WWWForm();
        LoginForm.AddField("Email",Email);



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
