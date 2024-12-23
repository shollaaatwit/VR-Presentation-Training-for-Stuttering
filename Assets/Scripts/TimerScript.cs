using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public TMP_Text timerText;
    public float time;

    private bool paused;

    void Start()
    {
        paused = true;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            // Updated timer UI
            time += Time.deltaTime;
            int minutes = (int)(time / 60f);
            int seconds = (int)(time - (60 * minutes));
            timerText.text = $"{minutes}:{seconds.ToString("00")}";
        }
    }
    // Pauses the timer
    public void PauseTimer()
    {
        paused = true;
    }

    // Resumes the timer
    public void ResumeTimer()
    {
        paused = false;
    }
}
