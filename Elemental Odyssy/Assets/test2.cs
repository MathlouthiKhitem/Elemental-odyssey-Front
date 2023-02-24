using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_InputField CodeInputField;
       public void OnTestClick()
    {

        
        StartCoroutine(TryTest());
        

    }
   private IEnumerator TryTest()
    {
        
        string CodeVerfication =CodeInputField.text ;
        Debug.Log("CodeInputField" + CodeInputField.text);
     //   WWWForm CodeVerficationForm = new WWWForm();
       // CodeVerficationForm.AddField("CodeVerfication",CodeVerfication);
        string storedString = PlayerPrefs.GetString("mycode");
        Debug.Log("GetString"+storedString);
        if(CodeVerfication == storedString){
    
          Debug.Log("code correct");
        }
    
        else
         {
            Debug.Log("unable to connect");
        }
        
        yield return null;  
    }
}
