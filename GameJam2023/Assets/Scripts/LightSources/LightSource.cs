using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour
{
    [SerializeField] protected float maxIntensity;
    [SerializeField] protected float speedDecreasingIntensity = 1f;
    [SerializeField] protected float lightIntensity;
    public float LightIntensity
    {
        get { return lightIntensity; }
        private set
        { 
            lightIntensity = value;

            if(lightIntensity <= 0.0f)
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
            }
        }
    }
    private ParticleSystem particles;
    private Light lightObj;
    public bool IsLit { get; private set; }
    protected int enemyInTrigger;

    protected virtual void Awake()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        particles.Stop();

        lightObj = GetComponentInChildren<Light>();
        lightObj.intensity = 0f;

        IsLit = false;
        lightIntensity = 0.0f;
        //Activate();
    }

    protected virtual void Update()
    {
        if (enemyInTrigger > 0 && IsLit)
        {
            LightIntensity -= (enemyInTrigger * speedDecreasingIntensity* Time.deltaTime);
            Debug.Log($"Light intensity = {LightIntensity}");
        }
    }

    protected virtual void Activate()
    {
        IsLit = true;
        particles.Play();
        lightIntensity = maxIntensity;
        lightObj.intensity = pointLightMaxIntensity;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger");
        if (other.CompareTag("Enemy"))
        {
            enemyInTrigger++;
            Debug.Log($"Tag compared");
            // Enemy enemy = other.GetComponent<Enemy>();
            // enemy.Brain.CurrentState = enemy.Brain.SiphoningState;
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInTrigger--;
        }
    }
}
