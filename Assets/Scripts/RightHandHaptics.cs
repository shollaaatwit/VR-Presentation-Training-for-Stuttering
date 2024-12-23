using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class RightHandHaptics : MonoBehaviour
{

    [SerializeField]
    private HapticImpulsePlayer haptic;

    [SerializeField]
    private AudioClip clip;

    private GameObject audioLocation;

    private void Start()
    {
        audioLocation = GameObject.FindGameObjectWithTag("MainCamera");
    }
    // Vibrates the right controller and plays the button noise
    public void VibrateController()
    {
        haptic.SendHapticImpulse(.5f, .25f);
        AudioSource.PlayClipAtPoint(clip, audioLocation.transform.position);
    }

}
