using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__
{
    public abstract class EnemySpawner : MonoBehaviour
    {
        public abstract void Spawn(int numberOfEnemies);
    }
}