using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace __Shooter__{
    public class HUD : MonoBehaviour
    {
        public RectTransform currentShield;
        public RectTransform maxShield;

        public RectTransform currentHP;

        public Text lives;
        public Text rockets;

        public Text score;
        public Text killcount;
        public Text coins;


        public Text timer;
        

        private Player player;

        // Start is called before the first frame update
        void Start()
        {
            player = GameManager.instance.player;
        }

        // Update is called once per frame
        void Update()
        {
            currentHP.sizeDelta = new Vector2 (180 * player.ship.hitpoints/100, currentHP.sizeDelta.y);

            currentShield.sizeDelta = new Vector2 (180 * player.ship.currentShield/100, currentShield.sizeDelta.y);
            maxShield.sizeDelta = new Vector2 (180 * player.ship.shieldCapacity/100, maxShield.sizeDelta.y);

            lives.text = "Lives: " + player.ship.lives;
            rockets.text = "Rockets: " + player.ship.currentRockets + "/" + player.ship.rocketsCapacity ;

            coins.text = "Coins: " + player.coins;
            killcount.text = "Enemies Killed: " + player.ship.killCount;
            score.text = "Score: " + player.score;

            timer.text = "Next round in\n" + (int)GameManager.instance.timer;
        }
    }
}
