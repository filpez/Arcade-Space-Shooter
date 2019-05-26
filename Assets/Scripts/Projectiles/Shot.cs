using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__ {
    public class Shot : MonoBehaviour
    {
        public Ship shooter;

        public int damage = 10;

        public float speed = 1500;

        Rigidbody rb;

        void OnEnable() {
            rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.forward * speed);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Ship>() != null && other.GetComponent<Ship>() != shooter)
            {
                Ship ship = other.GetComponent<Ship>();
                ship.TakeDamage(damage, shooter);
                
                Explode();

                gameObject.SetActive(false);
            }

            
        }

        public void OnTriggerExit(Collider other){
            if (other.gameObject.CompareTag("Limit"))
            {
                Explode();
                gameObject.SetActive(false);
            }
        }

        public void Explode(){
            GameObject explosion = ObjectPoolManager.instance.GetPooledObject("Shot Explosion");
            explosion.transform.position = transform.position;
            explosion.SetActive(true);
        }
    }
}

