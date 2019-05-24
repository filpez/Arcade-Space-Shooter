using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__
{
    public class ShieldEffect : MonoBehaviour
    {
        ParticleSystem myParticleSystem;
        ParticleSystem.EmissionModule emissionModule;

        Ship ship;

        float rateMultiplier = 0.5f;

        void Start()
        {
            // Get the system and the emission module.
            myParticleSystem = GetComponent<ParticleSystem>();
            emissionModule = myParticleSystem.emission;
            ship = transform.parent.GetComponent<Ship>();
        }

        void Update() {
            emissionModule.rateOverTime = ship.currentShield * rateMultiplier;
        }


    }
}
