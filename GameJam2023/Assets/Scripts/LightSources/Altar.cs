using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;

public class Altar : LightSource
{
    [SerializeField] private ParticleSystem[] candlesParticles;
    [SerializeField] private ParticleSystem godBeamParticles;

    bool isPrayed = false;

    public override float LightIntensity
    {
        get { return lightIntensity; }
        set
        {
            var temp = lightIntensity;
            lightIntensity = value;

            if (lightIntensity <= 0.0f)
            {
                IsLit = false;
                foreach (ParticleSystem ps in candlesParticles)
                {
                    ps.Stop();
                }
                godBeamParticles.Stop();
                if (isPrayed)
                {
                    isPrayed = false;
                    EventManager.Publish(GameEventType.HOTEL_LOST);
                }                
            }
            else if (temp > lightIntensity)
            {
                float percentage = lightIntensity / maxIntensity;
                var tempEmission = particles.main;
                tempEmission.startColor = new Color(
                    tempEmission.startColor.color.r,
                    tempEmission.startColor.color.g,
                    tempEmission.startColor.color.b,
                    temp);
                lightObj.intensity = pointLightMaxIntensity * percentage;
            }
            else if (lightIntensity >= maxIntensity)
            {
                GameManager.instance.Player.Animator.ResetTrigger("Prayer");
                GameManager.instance.Player.Animator.SetTrigger("Idle");
                EventManager.Publish(GameEventType.HOTEL_PRAYED);
                isPrayed = true;
                godBeamParticles.Play();
            }
        }
    }

    protected override void Awake()
    {
        foreach (ParticleSystem ps in candlesParticles)
        {
            ps.Stop();
        }

        godBeamParticles.Stop();

        lightObj = GetComponentInChildren<Light>();
        lightObj.intensity = 0f;

        IsLit = false;
        lightIntensity = 0.0f;
        //Activate();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Activate(string animType)
    {
        if (animType == "LightBrazier")
        {
            IsLit = true;
            lightObj.intensity = pointLightMaxIntensity;
            foreach (ParticleSystem ps in candlesParticles)
            {
                ps.Play();
            }

            EventManager.Publish(GameEventType.LIGHT_LIT);
        }

        if (animType == "Prayer")
        {
            LightIntensity += maxIntensity * 0.5f;
            lightObj.intensity = pointLightMaxIntensity;
            
        }
    }

    protected override void Activate(InputAction.CallbackContext c)
    {
        SetFire();
    }

    private void Pray(InputAction.CallbackContext c)
    {
        EventManager.Publish(GameEventType.PRAYING);
        GameManager.instance.Player.IsPraying = true;
        GameManager.instance.Player.Animator.SetTrigger("Kneeling");
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Player"))
        {
            if (!IsLit && other.GetComponent<Player>().HasTorch)
            {
                InputHandler.Unsubscribe(KeyAction.INTERACT);
                EventManager<string>.SubscribeParam(GameEventType.ANIM_OVER, Activate);
                InputHandler.Subscribe(KeyAction.INTERACT, Activate);
            }
            else if (IsLit && !other.GetComponent<Player>().HasTorch)
            {
                EventManager<string>.SubscribeParam(GameEventType.ANIM_OVER, Activate);
                InputHandler.Unsubscribe(KeyAction.INTERACT);
                InputHandler.Subscribe(KeyAction.INTERACT, Pray);
            }
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (other.CompareTag("Player"))
        {
            EventManager<string>.UnsubscribeParam(GameEventType.ANIM_OVER, Activate);
            InputHandler.Unsubscribe(KeyAction.INTERACT);
            other.GetComponent<Player>().IsPraying = false;
        }
    }
}
