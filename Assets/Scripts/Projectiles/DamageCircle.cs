using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__{
    public class DamageCircle : MonoBehaviour
    {
        public float smoothTime = 1;
        private float velocity = 0;

        //Texture diameter * spawn multipler(20) * 2(cause spawn uses radius)
        private float multiplier = 1024f/999 * 40;
        private float extra = 3;

        private float scale = 1000;
            
        // Update is called once per frame
        void FixedUpdate()
        {
            float targetScale =  multiplier * (ShipManager.instance.GetShips().Count + extra);
            scale = Mathf.SmoothDamp(scale, targetScale, ref velocity, smoothTime);
            float limit = scale * scale / 4;
            transform.localScale =  Vector3.one * scale;

            foreach (Ship ship in ShipManager.instance.GetShips()){
                if (ship.transform.position.sqrMagnitude > limit && Time.time - ship.lastHit >= 1){
                    ship.TakeDamage(10, null);
                }
            }


        }
    }
}

