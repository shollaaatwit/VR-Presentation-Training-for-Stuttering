using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public TMP_Text codeInput;
    public GameObject loadSaved;

    private void Update()
    {
        loadSaved.SetActive(SavedCodeExists());
    }
    // Verify the code is correct and load the next scene
    public void CheckVerifyCode()
    {
        StartCoroutine(CodeStorage.Instance.VerifyCode(codeInput.text));
    }

    // Clear our saved code
    public void Clear()
    {
        codeInput.text = "";
        PlayerPrefs.DeleteKey("PresentationCode");
    }

    // Save the code
    public void Save()
    {
        PlayerPrefs.SetString("PresentationCode", codeInput.text);
    }

    // If we have a saved code, load that presentation
    public void Load()
    {
        if (SavedCodeExists())
        {
            string code = PlayerPrefs.GetString("PresentationCode");
            if (code != null)
            {
                codeInput.text = code;
            }
        }
    }

    // Check if a saved code exists
    public bool SavedCodeExists()
    {
        bool exists = PlayerPrefs.HasKey("PresentationCode");
        return exists;
    }
}
