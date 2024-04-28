using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight_timer : MonoBehaviour
{
    [SerializeField] float toggleInterval = 0f;
    private float timer = 0f;
    private int CurrentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //print(timer);

        if (timer >= toggleInterval)
        {
            SwitchDayTime();
            timer = 0f;
        }  
        
    }

    void SwitchDayTime()
    {
        // Increment the index and wrap around if needed
        CurrentTime ++;
        if (CurrentTime > 3)
        {
            CurrentTime = 0;
        }
        //0= morning, 1= noon, 2= night, 3= dawn
    }
     
    public int GetCurrentTime()
    {
        return CurrentTime;
    }
}
