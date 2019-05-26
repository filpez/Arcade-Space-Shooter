using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__ {
    public class Rocket : MonoBehaviour
    {
        public Ship shooter;

        public int damage = 10;

        public int area = 10;

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
                foreach (Ship ship in ShipManager.instance.GetShips()){
                    if ((ship.transform.position - transform.position).sqrMagnitude < area * area && ship != shooter){
                        ship.TakeDamage(damage, shooter);
                    }
                }
                BigExplode();

                gameObject.SetActive(false);
            }

            
        }

        public void OnTriggerExit(Collider other){
            if (other.gameObject.CompareTag("Limit"))
            {
                SmallExplode();
                gameObject.SetActive(false);
            }
        }

        public void SmallExplode(){
            GameObject explosion = ObjectPoolManager.instance.GetPooledObject("Shot Explosion");
            explosion.transform.position = transform.position;
            explosion.SetActive(true);
        }

        public void BigExplode(){
            GameObject explosion = ObjectPoolManager.instance.GetPooledObject("Rocket Explosion");
            explosion.transform.position = transform.position;
            explosion.SetActive(true);
        }
    }
}

