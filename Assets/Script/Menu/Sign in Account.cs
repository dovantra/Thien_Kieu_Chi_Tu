using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;


public class SigninAccount : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public TextMeshProUGUI notification;

    public GameObject Account_screen;
    public GameObject SignIn_screen;
    public GameObject Menu_screen;

    public void LogIn_Button()
    {
        StartCoroutine(SignIn());
    }
    public void Back()
    {
        SignIn_screen.SetActive(false);
        notification.text = "";
        Account_screen.SetActive(true);
    }

    private IEnumerator SignIn()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", username.text);
        form.AddField("password", password.text);

        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/dangnhap.php", form);
        yield return www.SendWebRequest();

        if (!www.isDone)
        {
            notification.text = "Connection ERROR. Please try again.";
        }
        else
        {
            string get = www.downloadHandler.text;

            if(get == "empty")
            {
                notification.text = "Please fill in all required fields.";
            }else if(get == "" || get == null)
            {
                notification.text = "Incorrect username or password.";
            }else if (get.Contains("Lỗi"))
            {
                notification.text = "Cannot connect to the server. Please try again.";
            }
            else
            {
                notification.text = "Login successful! Welcome back.";
                PlayerPrefs.SetString("token", get);
                Debug.Log(get);
                StartCoroutine(WaitAndSwitchScene());
            }
        }
    }
    private IEnumerator WaitAndSwitchScene()
    {
        yield return new WaitForSeconds(2); // Dừng lại 2 giây
        SignIn_screen.SetActive(false);
        Menu_screen.SetActive(true);
    }
}
