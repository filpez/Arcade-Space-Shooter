using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__
{
    public class DestroyByTime : MonoBehaviour
    {
        public float lifetime;
        public bool poolable;

        void OnEnable()
        {
            StartCoroutine(DestroyObject());
        }

        IEnumerator DestroyObject()
        {
            yield return new WaitForSeconds(lifetime);
            if (poolable){
                gameObject.SetActive(false);
            }
            else{
                Destroy(gameObject);
            }
        }
    }
}