using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class KeyRebindHandler : MonoBehaviour
{
    public TMP_Text label;

    // Handles key rebidning
    public void RebindKey(InputActionReference refToRebind)
    {

        string originalKey = refToRebind.action.GetBindingDisplayString();
        refToRebind.action.Disable();
        var rebindOp = refToRebind.action.PerformInteractiveRebinding().Start().OnComplete(op =>
        {
            refToRebind.action.Enable();
            label.text = "Current Keybind: " + refToRebind.action.GetBindingDisplayString();
            Debug.Log("Successfully rebound " + originalKey + " to " + refToRebind.action.GetBindingDisplayString());
        });

    }

}
