using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__{

    public class Pointer : MonoBehaviour
    {
        Transform nearestShip = null;
        public Ship parentShip;
    
        void Update()
        {
            UpdateNearestShip();
            if (nearestShip != null){
                float nearestShipAngle = Vector3.SignedAngle( nearestShip.position - parentShip.transform.position, parentShip.transform.forward, Vector3.up);
                transform.localEulerAngles = new Vector3(90, 0, nearestShipAngle);


                
                nearestShipAngle *= Mathf.Deg2Rad;
                transform.localPosition = new Vector3(-Mathf.Sin(nearestShipAngle) * 8, 0, Mathf.Cos(nearestShipAngle) * 8);
            }
        }

        void UpdateNearestShip(){
            float nearestShipSqrDistance = Mathf.Infinity; 

            foreach (Ship ship in ShipManager.instance.GetShips()){
                float distance = (ship.transform.position - parentShip.transform.position).sqrMagnitude;
                if (distance < nearestShipSqrDistance && ship != parentShip){
                    nearestShipSqrDistance = distance;
                    nearestShip = ship.transform;
                }
            }
        }
    }
}
