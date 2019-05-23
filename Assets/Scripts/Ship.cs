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

        public int currentShield = 40;
        public int shield_capacity = 40;
        public static int max_shield = 100;

        public float shield_recharge_rate = 10;
        public static float min_shield_recharge_rate = 3;
        float lastHit = 0;


        public GameObject shotPrefab;

        public void FireShot(Vector3 target)
        {
            GameObject shot = Instantiate(shotPrefab, transform.position, Quaternion.FromToRotation(Vector3.forward, target - transform.position));
            shot.GetComponent<Shot>().shooter = this;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Shot>() != null)
            {
                Shot shot = other.GetComponent<Shot>();
                TakeDamage(shot.damage);
            }
        }

        public void TakeDamage(int damage)
        {
            if (currentShield > 0)
            {
                currentShield -= damage;
            }
            else
            {
                lives--;
            }

        }
    }
}
