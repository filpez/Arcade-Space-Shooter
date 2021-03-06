﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public int currentRound = 0;
        public float timer = 0;

        public static float roundTime = 60;

        public Player player;
        public EnemySpawner spawner;

        public GameObject shop;
        
        // Start is called before the first frame update
        void Awake()
        {
            instance = this;
        }

        void Update(){
            timer -= Time.deltaTime;

            if (ShipManager.instance.GetShips().Count <= 1){
                timer = 0;
            }

            if (timer <= 0){
                if (currentRound > 0)
                    OpenShop();
                currentRound++;
                spawner.Spawn(currentRound);
                timer = roundTime;
            }
        }

        public void OpenShop(){
            Time.timeScale = 0;
            shop.SetActive(true);
        }

        public void CloseShop(){
            Time.timeScale = 1;
            shop.SetActive(false);
        }
    }
}

