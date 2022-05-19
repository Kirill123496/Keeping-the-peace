using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{

    public Text timerText;              
    public Slider timerSlider;

    public bool active;                
    public float cooldown;             
    public float timer;                 

    void Update1()
    {
        if (active)
            timer -= Time.deltaTime;   
        if (timer < 0)
            timer = 0;                  
        UpdateUI();
    }

    void UpdateUI()
    {
        timerText.text = "Cooldown: " + timer;
        timerSlider.value = (timer / cooldown);
    }

    public void CompleteAction()
    {
        if (timer > 0)                  
            return;
        active = false;
        timer = cooldown;
        active = true;
    }
}