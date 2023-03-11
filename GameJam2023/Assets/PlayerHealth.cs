using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    Slider slider;
    public static Slider instance;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateHP()
    {
        //slider.value = 
    }
}
