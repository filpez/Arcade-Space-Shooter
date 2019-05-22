using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter{
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
    }
}

