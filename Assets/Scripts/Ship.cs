using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter{
    public class Ship : MonoBehaviour
    {
        public int lives = 3;
        public static int max_lives = 3;

        public int current_rockets = 3;
        public int rockets_capacity = 3;
        public static int max_rockets = 10;

        public int current_shield = 40;
        public int shield_capacity = 40;
        public static int max_shield = 100;

        public float shield_recharge_rate = 10;
        public static float min_shield_recharge_rate = 3;
        float lastHit = 0;

    }


}
