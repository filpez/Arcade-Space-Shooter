using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__
{
    public class Ship : MonoBehaviour
    {
        public int lives = 3;
        public static int max_lives = 3;

        public int current_rockets = 3;
        public int rockets_capacity = 3;
        public static int max_rockets = 10;

        public float currentShield = 40;
        public float shieldCapacity = 40;
        public static float maxShield = 100;

        public float shieldRechargeRate = 10;
        public static float minShieldRechargeRate = 3;

        public static int shieldRechargeSpeed = 10;
        float lastHit = 0;

        public static float thrust = 20;
        public static float drift = 1;

        public GameObject shotPrefab;

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
            GameObject shot = Instantiate(shotPrefab, transform.position, Quaternion.FromToRotation(Vector3.forward, target - transform.position));
            shot.GetComponent<Shot>().shooter = this;
        }

        public void TakeDamage(int damage)
        {
            lastHit = Time.time;

            if (currentShield > 0)
            {
                currentShield -= damage;
            }
            else
            {
                lives--;
            }
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
