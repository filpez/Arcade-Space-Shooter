﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__
{
    public class Ship : MonoBehaviour
    {
        public int lives = 3;
        public static int max_lives = 3;

        public int hitpoints = 100;
        public static int maxHitpoints = 100;

        public int currentRockets = 3;
        public int rockets_capacity = 3;
        public static int max_rockets = 10;

        public float currentShield = 40;
        public float shieldCapacity = 40;
        public static float maxShield = 100;

        public float shieldRechargeRate = 10;
        public static float minShieldRechargeRate = 3;

        public static int shieldRechargeSpeed = 10;
        public float lastHit = 0;

        public static float thrust = 20;
        public static float drift = 3;

        public int killCount = 0;

        public float fireRate = 0.5f;

        private float lastFire = 0;

        private Rigidbody rb;

        void Start() {
            rb = GetComponent<Rigidbody>();
            ShipManager.instance.RegisterShip(this);
        }

        void Update() {
            if(lastHit + shieldRechargeRate < Time.time){
                RechargeShield();
            }
        }

        public void RechargeShield()
        {
            currentShield += shieldRechargeSpeed * Time.deltaTime;
            if (currentShield > shieldCapacity){
                currentShield = shieldCapacity;
            }
        }

        public void FireShot(Vector3 target)
        {
            if (Time.time - lastFire > fireRate){
                GameObject shot = ObjectPoolManager.instance.GetPooledObject("Shot");
                shot.transform.position = transform.position;
                shot.transform.rotation = Quaternion.FromToRotation(Vector3.forward, target - transform.position);
                shot.GetComponent<Shot>().shooter = this;
                shot.SetActive(true);
                lastFire = Time.time;
            }
        }

        public void TakeDamage(int damage, Ship shooter)
        {
            lastHit = Time.time;

            if (currentShield > 0)
            {
                currentShield -= damage;
            }
            else if (hitpoints > 0)
            {
                hitpoints -= damage;
            }
            else if (lives > 0){
                Explode();
                
                Reset();
                lives--;
            }
            else {
                Debug.Log(shooter.killCount);
                if (shooter != null){
                    shooter.killCount++;
                    Debug.Log(shooter.killCount);
                }
                Die();
            }
        }

        private void Reset(){
            transform.position = Vector3.zero;
                transform.eulerAngles = Vector3.zero;
                rb.velocity = Vector3.zero;

                currentShield = shieldCapacity;
                hitpoints = maxHitpoints;
        }

        public void Explode()
        {
            GameObject explosion = ObjectPoolManager.instance.GetPooledObject("Player Explosion");
            explosion.transform.position = transform.position;
            explosion.SetActive(true);
        }

        public void Die()
        {
            GameObject coin = ObjectPoolManager.instance.GetPooledObject("Coin");
            coin.transform.position = transform.position;
            coin.SetActive(true);
            ShipManager.instance.RemoveShip(this);
            Destroy(gameObject);
        }
        public void MoveForward()
        {
            rb.velocity = transform.forward * thrust;
        }

        public void RotateRight()
        {
            rb.angularVelocity = transform.up * drift;
        }

        public void RotateLeft()
        {
            rb.angularVelocity = - transform.up * drift;
        }
    }
}
