using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace __Shooter__
{
    public class ShopMenu : MonoBehaviour
    {
        [Header("Lives")]
        public Button livesButton;
        public Text livesText;
        public int livesPrice = 3;

        [Header("Rockets")]
        public Button rechargeRocketsButton;
        public int rechargeRocketsPrice = 1;
        public Button maxRocketsButton;
        public Text maxRocketsText;
        public int maxRocketsPrice = 5;

        [Header("Shield")]
        public Button shieldRateButton;
        public Text shieldRateText;
        public int shieldRatePrice = 5;

        public Button maxShieldButton;
        public Text maxShieldText;
        public int maxShieldPrice = 2;

        private Player _player;

        public void Start(){
            _player = GameManager.instance.player;
        }

        public void Update(){
            livesButton.interactable = _player.ship.lives < Ship.maxLives && _player.coins >= livesPrice;
            livesText.text = "" + _player.ship.lives + "/" + Ship.maxLives;

            rechargeRocketsButton.interactable = _player.ship.currentRockets < _player.ship.rocketsCapacity && _player.coins >= rechargeRocketsPrice;

            maxRocketsButton.interactable = _player.ship.rocketsCapacity < Ship.maxRockets && _player.coins >= maxRocketsPrice;
            maxRocketsText.text = "" + _player.ship.rocketsCapacity + "/" + Ship.maxRockets;

            shieldRateButton.interactable = _player.ship.shieldRechargeRate > Ship.minShieldRechargeRate && _player.coins >= shieldRatePrice;
            shieldRateText.text = "" + _player.ship.shieldRechargeRate + "s/" + Ship.minShieldRechargeRate + "s";

            maxShieldButton.interactable = _player.ship.shieldCapacity < Ship.maxShield && _player.coins >= maxShieldPrice;
            maxShieldText.text = "" + _player.ship.shieldCapacity + "/" + Ship.maxShield;

            

        }
        public void Continue()
        {
            GameManager.instance.CloseShop();
        }

        public void MoreLife()
        {
            _player.ship.lives += 1;
            _player.coins -= livesPrice;
        }

        public void RechargeRockets()
        {
            _player.ship.currentRockets = _player.ship.rocketsCapacity;
            _player.coins -= rechargeRocketsPrice;
        }

        public void MoreRockets()
        {
            _player.ship.rocketsCapacity += 1;
            _player.coins -= maxRocketsPrice;
        }

        public void LessRecharge()
        {
            _player.ship.shieldRechargeRate += 1;
            _player.coins -= shieldRatePrice;
        }

        public void MoreShield()
        {
            _player.ship.shieldCapacity += 10;
            _player.coins -= maxShieldPrice;
        }
    }
}
