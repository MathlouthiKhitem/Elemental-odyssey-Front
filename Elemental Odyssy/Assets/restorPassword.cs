using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
public class restorPassword : MonoBehaviour
{
       [SerializeField] private string authURL = "http://127.0.0.1:9090/user/restorPassword";
    [SerializeField] private TMPro.TMP_InputField PasswordRepetInputField;
    [SerializeField] private TMPro.TMP_InputField PasswordInputField;
    
    public void OnPasswordClick()
    {

        StartCoroutine(TryPassword());
        

    }
    private IEnumerator TryPassword()
    {
         string EmailPlayerPrefs = PlayerPrefs.GetString("Email");
             Debug.Log("////////  "+ EmailPlayerPrefs);
       string PasswordRepet = PasswordRepetInputField.text;
        string Password = PasswordInputField.text;
        Debug.Log(EmailPlayerPrefs + " " + Password);
        WWWForm PasswordForm = new WWWForm();
        PasswordForm.AddField("Email",EmailPlayerPrefs);
        PasswordForm.AddField("Password",Password);
       
        if(PasswordRepet == Password){
        Debug.Log("asbaaaaaaaaa");
      
        UnityWebRequest request = UnityWebRequest.Post(authURL,PasswordForm);
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
      
}
