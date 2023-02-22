using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
public class EditProfile : MonoBehaviour
{
   [SerializeField] private string authURL = "http://127.0.0.1:9090/user/putOnce";
    [SerializeField] private TMPro.TMP_InputField EmailInputField;
    [SerializeField] private TMPro.TMP_InputField PasswordInputField;
    [SerializeField] private TMPro.TMP_InputField AgeInputField;
   //  private RawImage ProfileImage;
    
    public void OnEditProfileClick()
    {

        StartCoroutine(TryEditProfile());
        

    }
    private IEnumerator TryEditProfile()
    {
        string Email = EmailInputField.text;
        string Password = PasswordInputField.text;
         string Age = AgeInputField.text;
        Debug.Log(Email + " " + Password+ " "+Age);
        WWWForm EditForm = new WWWForm();
        EditForm.AddField("Email",Email);
        EditForm.AddField("Password",Password);
        EditForm.AddField("Age",Age);
        UnityWebRequest request = UnityWebRequest.Post(authURL,EditForm);
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
