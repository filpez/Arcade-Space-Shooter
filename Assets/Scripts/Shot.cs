using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__ {
    public class Shot : MonoBehaviour
    {
        public Ship shooter;

        public int damage = 10;

        public static float speed = 1500;

        Rigidbody rb;

        void Start() {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * speed);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Ship>() != null)
            {
                Ship ship = other.GetComponent<Ship>();
                ship.TakeDamage(damage);
            }
        }
    }
}

