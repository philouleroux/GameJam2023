using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour
{
    [SerializeField] private float maxIntensity;
    private float lightIntensity;
    public float LightIntensity
    {
        get { return lightIntensity; }
        private set
        { 
            lightIntensity = value;

            if(lightIntensity <= 0.0f)
            {
                IsLit = false;
            }
        }
    }
    private ParticleSystem particles;
    public bool IsLit { get; private set; }
    private int enemyInTrigger;

    protected virtual void Awake()
    {
        particles = GetComponent<ParticleSystem>();
        IsLit = false;
        lightIntensity = 0.0f;
    }

    protected virtual void Update()
    {
        if (enemyInTrigger > 0 && IsLit)
        {
            LightIntensity -= 1.0f * (float)enemyInTrigger * Time.deltaTime;
        }
    }

    protected virtual void Activate()
    {
        if (!IsLit)
        {
            IsLit = true;
            particles.Play();
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInTrigger++;
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
