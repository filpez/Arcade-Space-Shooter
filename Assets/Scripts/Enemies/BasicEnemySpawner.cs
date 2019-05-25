using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__
{
    public class BasicEnemySpawner : EnemySpawner
    {
        public GameObject enemyPrefab;

        public int distanceMultiplier;

        public List<Material> mainColors;

        public List<Material> secundaryColors;
        public override void Spawn(int numberOfEnemies){
            float radius = (ShipManager.instance.GetShips().Count + numberOfEnemies) * distanceMultiplier;

            for (int i = 1; i <= numberOfEnemies; i++){
                float angle = 2*Mathf.PI/numberOfEnemies * i;
                GameObject enemy = Instantiate(enemyPrefab, new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle))*radius, Quaternion.identity);
                
                Material mainColor = mainColors[Random.Range(0, mainColors.Count)];
                Material secundaryColor = secundaryColors[Random.Range(0, secundaryColors.Count)];
                
                MeshRenderer shipRenderer = enemy.transform.Find("SpaceCruiser").GetComponent<MeshRenderer>();
                MeshRenderer exhaustRenderer = enemy.transform.Find("Exhaust Outlet").GetComponent<MeshRenderer>();
                
                Material[] shipMaterials  = shipRenderer.materials;
                Material[] exhaustMaterials = exhaustRenderer.materials;

                shipMaterials[0] = mainColor;
                shipMaterials[1] = secundaryColor;
                shipMaterials[3] = secundaryColor;
                exhaustMaterials[0] = secundaryColor;

                shipRenderer.materials = shipMaterials;
                exhaustRenderer.materials = exhaustMaterials;
            }
        }
    }
}