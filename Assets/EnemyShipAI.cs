using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__{
    public class EnemyShipAI : MonoBehaviour
    {
        Transform nearestShip = null;
        public float nearestShipSqrDistance = Mathf.Infinity;

        public float nearestShipAngle = Mathf.Infinity;


        public float fireRate = 0.5f;

        public float fireDistance = 100;

        public float thurstDistance = 10;

        __Input__.ICommand fireShot;
        __Input__.ICommand fireMissile;
        __Input__.ICommand rotateLeft;
        __Input__.ICommand rotateRight;
        __Input__.ICommand moveForward;

        Ship _ship;
        
        // Start is called before the first frame update
        void Start()
        {
            _ship = GetComponent<__Shooter__.Ship>();
            fireShot = new __Input__.FireShot();
            moveForward = new __Input__.MoveForward();
            rotateLeft = new __Input__.RotateLeft();
            rotateRight = new __Input__.RotateRight();
            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            UpdateNearestShip();

            nearestShipAngle = Vector3.SignedAngle(transform.forward, nearestShip.position - transform.position, Vector3.up);
            Debug.LogError(nearestShipAngle);
            if (nearestShipAngle > 30) {
                Debug.Log("Right");
                rotateRight.Execute(_ship);
            }
            else if (nearestShipAngle < -30) {
                Debug.Log("Left");
                rotateLeft.Execute(_ship);
            }
            else if (nearestShipSqrDistance > thurstDistance * thurstDistance){
                Debug.Log("Go");
                moveForward.Execute(_ship);
            }

            if (nearestShipSqrDistance < fireDistance * fireDistance){
                ((__Input__.FireShot)fireShot).target = nearestShip.position;
                ((__Input__.FireShot)fireShot).target.y = 0;
                fireShot.Execute(_ship);
            }
            
            
            

        }

        void UpdateNearestShip(){
            nearestShipSqrDistance = Mathf.Infinity; 
            Vector3 _temp;
            foreach (Ship ship in ShipManager.instance.GetShips()){
                _temp = ship.transform.position - transform.position;
                float distance = _temp.sqrMagnitude;
                if (distance < nearestShipSqrDistance && ship != _ship){
                    nearestShipSqrDistance = distance;
                    nearestShip = ship.transform;
                }
            }
        }
    }
}
