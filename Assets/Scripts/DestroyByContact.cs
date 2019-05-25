using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__
{
    public class DestroyByContact : MonoBehaviour
    {
        public bool poolable;

        public void OnTriggerEnter(Collider other)
        {
            if (poolable){
                gameObject.SetActive(false);
            }
            else{
                Destroy(gameObject);
            }
        }
    }
}