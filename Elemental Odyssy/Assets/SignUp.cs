using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SignUp : MonoBehaviour
{

    [SerializeField] private string authURL = "http://127.0.0.1:9090/user/signup";
    [SerializeField] private TMPro.TMP_InputField FirstNameInputField;
    [SerializeField] private TMPro.TMP_InputField LastNameInputField;
    [SerializeField] private TMPro.TMP_InputField EmailInputField;
    [SerializeField] private TMPro.TMP_InputField AgeInputField;
    [SerializeField] private TMPro.TMP_InputField PasswordInputField;
    
    public void OnSignUpClick()
    {

        StartCoroutine(TrySignUp());
        

    }
    private IEnumerator TrySignUp()
    {
        string FirstName = FirstNameInputField.text;
        string LastName = LastNameInputField.text;
        string Email = EmailInputField.text;
        string Age = AgeInputField.text;
        string Password = PasswordInputField.text;
        Debug.Log(FirstName + " " + Password);
        WWWForm LoginForm = new WWWForm();
        LoginForm.AddField("FirstName",FirstName);
        LoginForm.AddField("LastName",LastName);
        LoginForm.AddField("Email",Email);
        LoginForm.AddField("Age",Age);
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
