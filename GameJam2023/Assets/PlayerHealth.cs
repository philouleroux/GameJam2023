using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : LightSource
{
    Slider slider;
    public static Slider instance;

    [SerializeField] float lerpSpeed = 1f;

    private float valueForSlider = 1f;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        //lightIntensity / maxIntensity
    }

    public void UpdateHP()
    {
        valueForSlider = lightIntensity / maxIntensity;
    }

    private void Update()
    {
        slider.value = Mathf.Lerp(slider.value, valueForSlider, lerpSpeed);
        UpdateHP();
    }
}
