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

    public class MoveForward : ICommand { 
        public void Execute(__Shooter__.Ship ship)
        {
            ship.MoveForward();
        }

    }

    public class RotateLeft : ICommand { 
        public void Execute(__Shooter__.Ship ship)
        {
            ship.RotateLeft();
        }

    }

    public class RotateRight : ICommand { 
        public void Execute(__Shooter__.Ship ship)
        {
            ship.RotateRight();
        }

    }

}