using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Input__ {
    public interface ICommand{
        void Execute(__Shooter__.Ship ship);
    }

    public class FireShot : ICommand {
        public Vector3 target;
        public void Execute(__Shooter__.Ship ship)
        {
            ship.FireShot(target);
        }

    }

}