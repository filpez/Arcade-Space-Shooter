using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__{
    public class Player: MonoBehaviour{

        public Ship ship;

        public int coins = 0;
        public int score = 0;

        private int extraScore = 0;

        void AddScore(int s){
            extraScore += s;
        }
        
        void Update(){
            score = extraScore + ship.killCount;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
               coins++;
            }
        }
    }
}