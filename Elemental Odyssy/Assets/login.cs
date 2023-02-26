using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;


public class login : MonoBehaviour
{  
    [SerializeField] private string authURL = "http://127.0.0.1:9090/user/signin";
    [SerializeField] private TMPro.TMP_InputField EmailInputField;
    [SerializeField] private TMPro.TMP_InputField PasswordInputField;
    
    public void OnLoginClick()
    {

        StartCoroutine(TryLogin());
        

    }
    private IEnumerator TryLogin()
    {
        string Email = EmailInputField.text;
        string Password = PasswordInputField.text;
        Debug.Log(Email + " " + Password);
        WWWForm LoginForm = new WWWForm();
        LoginForm.AddField("Email",Email);
        LoginForm.AddField("Password",Password);
       
        
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
