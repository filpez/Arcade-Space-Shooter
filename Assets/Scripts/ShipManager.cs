using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__{
    public class ShipManager : MonoBehaviour
    {
        public static ShipManager instance;
        List<Ship> ships;
        
        // Start is called before the first frame update
        void Awake()
        {
            ships = new List<Ship>();
            instance = this;
        }

        // Update is called once per frame
        public void RegisterShip(Ship ship)
        {
            ships.Add(ship);
        }

        public List<Ship> GetShips(){
            return ships;
        }
    }
}

