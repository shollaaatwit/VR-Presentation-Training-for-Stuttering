using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ChangeImageOnInput : MonoBehaviour
{

    public InputActionReference forwardButton;
    public InputActionReference backButton;

    public GameObject[] screens;
    public AudioClip audioClip;

    private Texture2D[] slides;
    private int _currentImage;
    private string _derivedUrl;
    private CodeStorage _codeStorage;
    private Transform playerTransform;
    private RightHandHaptics _rightHandHaptics;

    private void Awake()
    {
        forwardButton.action.started += ForwardSlide;
        backButton.action.started += BackSlide;
        _codeStorage = CodeStorage.Instance;
        _rightHandHaptics = GameObject.FindObjectOfType<RightHandHaptics>();
    }


    // Updates the computer screen and projector screen
    // with the correct slide
    private void updateAllScreens(Texture2D newImage)
    {
        foreach (GameObject screen in screens)
        {
            screen.GetComponent<RawImage>().texture = newImage;

        }
    }

    // If we dont have the current image cached we need to grab it
    // from the server, otherwise just update it
    private void updateCurrentImage()
    {
        if (slides[_currentImage] == null)
        {
            StartCoroutine(GetImageByIndex(_derivedUrl, _currentImage));
        }
        else
        {
            updateAllScreens(slides[_currentImage]);
        }

        AudioSource.PlayClipAtPoint(audioClip, playerTransform.position);
    }

    // Move forward a slide
    public void ForwardSlide(InputAction.CallbackContext context)
    {
        if (_currentImage < slides.Length - 1)
        {
            _currentImage++;
            updateCurrentImage();
            _rightHandHaptics.VibrateController();
        }

    }

    // Move backward a slide
    public void BackSlide(InputAction.CallbackContext context)
    {
        if (_currentImage > 0)
        {
            _currentImage--;
            updateCurrentImage();
            _rightHandHaptics.VibrateController();
        }

    }


    // Get slide image from server
    IEnumerator GetImageByIndex(string url, int index)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture($"{url}?index={index}");
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
            Debug.Log(request.url);
        }
        else
        {
            slides[index] = ((DownloadHandlerTexture)request.downloadHandler).texture;
            updateAllScreens(slides[_currentImage]);
        }
    }


    [Serializable]
    public class ResponseShape
    {
        public int slides;
    }
    // Gets num slides in the presentation
    public IEnumerator GetImageCount(string url)
    {
        // Get the total number of images in the slide deck.
        UnityWebRequest request = UnityWebRequest.Get($"{url}");

        request.timeout = 50000; // This is here to prevent an early timeout that was causing errors to be logged incorrectly.

        yield return request.SendWebRequest();
        switch (request.result)
        {
            case UnityWebRequest.Result.Success:
                ResponseShape data = JsonUtility.FromJson<ResponseShape>(request.downloadHandler.text);
                slides = new Texture2D[data.slides];

                break;
            case UnityWebRequest.Result.InProgress:
                break;
            default:
                Debug.Log($"Encountered {request.error} while requesting from {request.url}");
                Debug.Log(request.result);
                break;
        }

    }
 
    void Start()
    {
        _derivedUrl = $"{_codeStorage.baseUrl}/{_codeStorage.folderCode}";
        _currentImage = 0;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(GetImageCount(_derivedUrl));
        StartCoroutine(GetImageByIndex(_derivedUrl, 0));
    }


}
