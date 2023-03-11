using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torch : LightSource
{
    [SerializeField] Slider slider;
    [SerializeField] float lerpSpeed = 1f;

    private float valueForSlider = 1f;

    public void UpdateHP() => valueForSlider = lightIntensity / maxIntensity;


    private void UpdateUI() => slider.value = Mathf.Lerp(slider.value, valueForSlider, lerpSpeed);


    protected override void Update()
    {
        base.Update();
        UpdateUI();
    }
}
