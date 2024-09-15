using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RealTimer : MonoBehaviour
{
    public int hours;
    public int minutes;
    public int seconds;
    
    
    private DateTime startTime;
    private DateTime endTime;
    
    private Coroutine timerCoroutine;



    public void StartTimer()
    {
        startTime = DateTime.Now;
        TimeSpan time = new TimeSpan(hours, minutes, seconds);
        endTime = startTime.Add(time);
        
        
        timerCoroutine = StartCoroutine(Timer());
    }
    
    private IEnumerator Timer()
    {
        TimeSpan timeLeft = endTime - DateTime.Now;
        float totalSecondsLeft = (float) timeLeft.TotalSeconds;
        
        string text;
        
        while (true)    // 因為是coroutine，所以可以這樣寫
        {
            text = "";
            // timeLeftSlider.value = 1- (totalSecondsLeft / totalSeconds);
            
            if (totalSecondsLeft > 1)
            {
                if (timeLeft.Hours > 0)
                {
                    text += timeLeft.Hours + "h ";
                    text += timeLeft.Minutes + "m ";
                    yield return new WaitForSeconds(timeLeft.Seconds);
                }
                else if (timeLeft.Minutes > 0)
                {
                    TimeSpan ts = TimeSpan.FromSeconds(totalSecondsLeft);
                    text += ts.Minutes + "m ";
                    text += ts.Seconds + "s ";
                }
                else
                {
                    text += Mathf.FloorToInt((float) totalSecondsLeft) + "s ";
                }
                
                // timeLeftText.text = text;

                totalSecondsLeft -= Time.deltaTime;
                yield return null;
            }
            else
            {
                
                // HandleTimesUpUI();
                break;
            }
        }
        
        yield return null;
    }
    
    private void Skip()
    {
        StopCoroutine(timerCoroutine);
        
        // HandleTimesUpUI();
        
    }
}
