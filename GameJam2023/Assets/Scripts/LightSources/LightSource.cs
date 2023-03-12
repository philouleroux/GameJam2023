using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.VirtualTexturing;
using Utilities;

public class LightSource : MonoBehaviour
{
    [SerializeField] protected float maxIntensity;
    [SerializeField] protected float speedDecreasingIntensity = 1f;
    [SerializeField] protected float pointLightMaxIntensity;
    protected float lightIntensity;

    protected System.Action<InputAction.CallbackContext> lastCallback;
    public virtual float LightIntensity
    {
        get { return lightIntensity; }
        protected set
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
    protected ParticleSystem particles;
    protected Light lightObj;
    public bool IsLit { get; protected set; }
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
        EventManager.Publish(GameEventType.LIGHT_LIT);
        Debug.Log("LIGHT_LIT published");
    }

    protected virtual void Activate(InputAction.CallbackContext c)
    {
        Activate();
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

        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Player>().HasTorch)
            {
                if (lastCallback != null)
                {
                    lastCallback = InputHandler.Unsubscribe(KeyAction.INTERACT);
                }
                InputHandler.Subscribe(KeyAction.INTERACT, Activate);
            }
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInTrigger--;
        }

        if (other.CompareTag("Player"))
        {
            InputHandler.Unsubscribe(KeyAction.INTERACT);
            if (lastCallback != null)
            {
                InputHandler.Subscribe(KeyAction.INTERACT, lastCallback);
            }
        }
    }
}
