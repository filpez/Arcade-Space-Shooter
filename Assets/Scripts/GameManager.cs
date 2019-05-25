using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public int currentRound = 0;
        public float timer = 0;

        public static float roundTime = 60;

        public EnemySpawner spawner;
        
        // Start is called before the first frame update
        void Start()
        {
            instance = this;
        }

        void Update(){
            timer -= Time.deltaTime;

            if (timer <= 0){
                currentRound++;
                spawner.Spawn(currentRound);
                timer = roundTime;
            }
        }
    }
}

