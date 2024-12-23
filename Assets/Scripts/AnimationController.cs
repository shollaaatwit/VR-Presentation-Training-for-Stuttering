using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public int chanceToAnimate = 5;
    public Animator animator;
    public int randomNumber;
    private bool finger, shrug1, shrug2, shrug3, cough, dust, lookAround, relaxed, touchHair, Standing, thinking, nervous, idle1, idle2;
    public int coolDownForNextAnimation;
    public GlobalAnimationTracker globalAnimationTracker;
    public float minCooldown = 2f;
    public float maxCooldown = 5f;
    private float nextAvailableTime = 0f;
    public float randomOffset;
    void Start()
    {
        randomOffset = Random.Range(0f, 1f);
        animator = GetComponent<Animator>();
        // StartCoroutine("PeriodicAnimation");
        float speedToWaitInterval = Random.Range(0.2f, 4.0f);
        float speedToWait = Random.Range(0.2f, 10.0f);
        InvokeRepeating("AnimationChance", speedToWait, speedToWaitInterval);
    }

    // Updates animator with correct values
    void Update()
    {
        randomNumber = Random.Range(0, 100);
        animator.SetBool("Finger1", finger);
        animator.SetBool("Shrug1", shrug1);
        animator.SetBool("Shrug2", shrug2);
        animator.SetBool("Shrug3", shrug3);
        animator.SetBool("Cough1", cough);
        animator.SetBool("Dust1", dust);
        animator.SetBool("LookAround1", lookAround);
        animator.SetBool("Relaxed", relaxed);
        animator.SetBool("Touch Hair", touchHair);
        animator.SetBool("Thinking", thinking);
        animator.SetBool("Nervous", nervous);
        animator.SetBool("Idle1", idle1);
        animator.SetBool("Idle2", idle2);
        animator.SetFloat("Speed Modifier", Random.Range(1.1f, 1.9f));
        animator.SetFloat("CycleOffset", Random.Range(1.0f, 3.0f));
    }

    // Sets up animation
    public void AnimationChance()
    {
        if (Time.time < nextAvailableTime + randomOffset)
            return; 
        SetAllToFalse();
        int randNum = Random.Range(0, 100);
        // if(randNum <= chanceToAnimate) 
        // {
        //     finger = true;
        // }
        // else if(randNum > chanceToAnimate && randNum <= chanceToAnimate*2) 
        // {
        //     shrug1 = true;
        // }
        // else if(randNum > chanceToAnimate*2 && randNum <= chanceToAnimate*3) 
        // {
        //     shrug2 = true;
        // }
        // else if(randNum > chanceToAnimate*3 && randNum <= chanceToAnimate*4) 
        // {
        //     shrug3 = true;
        // }
        // else if(randNum > chanceToAnimate*4 && randNum <= chanceToAnimate*5) 
        // {
        //     cough = true;
        // }
        // else if(randNum > chanceToAnimate*5 && randNum <= chanceToAnimate*6) 
        // {
        //     dust = true;
        // }
        // else if(randNum > chanceToAnimate*6 && randNum <= chanceToAnimate*7) 
        // {
        //     lookAround = true;
        // }
        // else if(randNum > chanceToAnimate*7 && randNum <= chanceToAnimate*8) 
        // {
        //     relaxed = true;
        // }
        // else if(randNum > chanceToAnimate*8 && randNum <= chanceToAnimate*9) 
        // {
        //     touchHair = true;
        // }
        // else if(randNum > chanceToAnimate*9 && randNum <= chanceToAnimate*10)
        // {
        //     thinking = true;
        // }
        // else if(randNum > chanceToAnimate*10 && randNum <= chanceToAnimate*11)
        // {
        //     nervous = true;
        // }
        // else if(randNum > chanceToAnimate*11 && randNum <= chanceToAnimate*12)
        // {
        //     idle1 = true;
        // }
        // else if(randNum > chanceToAnimate*12 && randNum <= chanceToAnimate*13)
        // {
        //     idle2 = true;
        // }
        int bucket = (int)(randNum / chanceToAnimate);

        switch (bucket)
        {
            case 0:
                finger = true;
                break;
            case 1:
                shrug1 = true;
                break;
            case 2:
                shrug2 = true;
                break;
            case 3:
                shrug3 = true;
                break;
            case 4:
                cough = true;
                break;
            case 5:
                dust = true;
                break;
            case 6:
                lookAround = true;
                break;
            case 7:
                relaxed = true;
                break;
            case 8:
                touchHair = true;
                break;
            case 9:
                thinking = true;
                break;
            case 10:
                nervous = true;
                break;
            case 11:
                idle1 = true;
                break;
            case 12:
                idle2 = true;
                break;
            default:
                // Handle cases outside the expected range if needed
                break;
        }
        nextAvailableTime = Time.time + Random.Range(minCooldown, maxCooldown);
    }

    public void SetAllToFalse()
    {
        finger = false;
        shrug1 = false;
        shrug2 = false;
        shrug3 = false;
        cough = false;
        dust = false;
        lookAround = false;
        relaxed = false;
        touchHair = false;
        nervous = false;
        thinking = false;
        idle1 = false;
        idle2 = false;
    }

    IEnumerator PeriodicAnimation()
    {
        float speedToWait = Random.Range(0.2f, 4.0f);
        yield return new WaitForSeconds(speedToWait);
        int randNumber = Random.Range(0, 100);
        // AnimationChance(randNumber);
    }

}
