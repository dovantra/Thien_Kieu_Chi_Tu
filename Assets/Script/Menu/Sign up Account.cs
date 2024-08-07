using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class SignupAccount : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public TextMeshProUGUI notification;

    public GameObject Account_screen;
    public GameObject SignUp_screen;
    public GameObject SignIn_screen;

    public void SignUp_Button()
    {
        StartCoroutine(SignUp());
    }

    public void Back()
    {
        SignUp_screen.SetActive(false);
        notification.text = "";
        Account_screen.SetActive(true);
    }

    private IEnumerator SignUp()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", username.text);
        form.AddField("passwd", password.text); // Sửa lỗi ở đây

        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/dangky.php", form);
        yield return www.SendWebRequest(); // Khi máy chủ phản hồi cả đc hay ko đc thì mới chạy code tiếp

        if (www.result != UnityWebRequest.Result.Success)
        {
            notification.text = "Error: " + www.error;
        }
        else
        {
            string get = www.downloadHandler.text;

            switch (get)
            {
                case "exist":
                    notification.text = "This account already exists. Please try another.";
                    break;
                case "OK":
                    notification.text = "Sign up successful! Welcome to our game.";
                    StartCoroutine(WaitAndSwitchScene()); // Bắt đầu coroutine mới để dừng lại 2 giây
                    break;
                case "ERROR":
                    notification.text = "Sign up failed! Please try again.";
                    break;
                default:
                    notification.text = "Connection ERROR. Please try again.";
                    break;
            }
        }
    }

    private IEnumerator WaitAndSwitchScene()
    {
        yield return new WaitForSeconds(2); // Dừng lại 2 giây
        SignUp_screen.SetActive(false);
        SignIn_screen.SetActive(true);
    }
}
