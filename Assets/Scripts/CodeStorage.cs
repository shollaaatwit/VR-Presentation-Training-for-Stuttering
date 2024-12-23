using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CodeStorage : MonoBehaviour
{
    private static CodeStorage _instance;
    public static CodeStorage Instance { get { return _instance; } }

    public string folderCode = "";

    public string baseUrl = "";

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    // Called in UI
    public void VerifyCodeWrapper(string fcode)
    {
        StartCoroutine(VerifyCode(fcode));
    }

    // If we are given a legitamate code, saves it 
    // and starts the presentation scene
    public IEnumerator VerifyCode(string fCode)
    {
        // Get the total number of images in the slide deck.
        UnityWebRequest request = UnityWebRequest.Get($"{baseUrl}/{fCode}");

        request.timeout = 50000; // This is here to prevent an early timeout that was causing errors to be logged incorrectly.

        yield return request.SendWebRequest();
        switch (request.result)
        {
            case UnityWebRequest.Result.Success:
                folderCode = fCode;
                SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex+1));
                break;
            case UnityWebRequest.Result.InProgress:
                Debug.Log("in progress...");
                break;
            default:
                Debug.Log($"Encountered {request.error} while requesting from {request.url}");
                Debug.Log(request.result);
                break;
        }


    }

}
