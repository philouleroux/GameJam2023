using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Torch : LightSource
{
    public override float LightIntensity
    {
        get { return lightIntensity; }
        set
        {
            lightIntensity = value;

            if (lightIntensity <= 0.0f)
            {
                IsLit = false;
                particles.Stop();
            }
            else
            {
                float temp = lightIntensity / maxIntensity;
                var tempEmission = particles.main;
                tempEmission.startColor = new Color(
                    tempEmission.startColor.color.r,
                    tempEmission.startColor.color.g,
                    tempEmission.startColor.color.b,
                    temp);
                lightObj.intensity = pointLightMaxIntensity * temp;
                UpdateHP();
            }
        }
    }
    [SerializeField]
    Slider slider;

    [SerializeField] 
    float lerpSpeed = 1f;

    private float valueForSlider = 1f;

  
    public void UpdateHP() => valueForSlider = lightIntensity / maxIntensity;


    private void UpdateUI()
    {
        slider.value = Mathf.Lerp(slider.value, valueForSlider, lerpSpeed);
        Debug.Log($"slider.value = {slider.value}");
        if (slider.value < 0.001f)
        {
            Debug.Log("Dead");
            DeathUI.instance.ShowUI();
            gameObject.SetActive(false);
        }
    }

    public void Start()
    {
        base.Awake();
        Activate();
    }

    protected override void Update()
    {
        base.Update();
        UpdateUI();
    }
}
