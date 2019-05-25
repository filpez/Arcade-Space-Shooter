using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__{
    public class Player: MonoBehaviour{

        public int coins = 0;
        
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
               coins++;
            }
        }
    }
}