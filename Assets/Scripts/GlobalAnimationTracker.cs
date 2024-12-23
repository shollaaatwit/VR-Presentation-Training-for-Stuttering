using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAnimationTracker : MonoBehaviour
{
    // Keeps track of animations going on
    public int totalAmountOfAnimations = 0;

    // Inc anim count
    public void IncrementAnimationCount()
    {
        totalAmountOfAnimations++;
    }

    // Dec anim count
    public void DecrementAnimationCount()
    {
        totalAmountOfAnimations--;
    }
}
