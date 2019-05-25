using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__{
    public class FollowPlayer : MonoBehaviour
    {
        Transform playerTransform;

        public float smoothTime = 1;
        private Vector3 velocity = Vector3.zero;
        
        // Start is called before the first frame update
        void Start()
        {
            playerTransform = GameManager.instance.player.transform;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 target = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
            transform.position =  Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);
        }
    }
}

