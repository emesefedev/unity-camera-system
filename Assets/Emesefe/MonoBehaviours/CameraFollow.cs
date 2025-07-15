using System;
using UnityEngine;

namespace Emesefe.MonoBehaviours
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float speed = 5;
        
        private Func<Vector3> _getCameraFollowPositionFunc;
        private void Update()
        {
            HandleMovement();
            HandleZoom();
        }

        public void Setup(Func<Vector3> getCameraFollowPositionFunc)
        {
            _getCameraFollowPositionFunc = getCameraFollowPositionFunc;
        }

        public void SetGetCameraFollowPositionFunc(Func<Vector3> getCameraFollowPositionFunc)
        {
            _getCameraFollowPositionFunc = getCameraFollowPositionFunc;
        }

        private void HandleMovement()
        {
            Vector3 cameraFollowPosition = _getCameraFollowPositionFunc();
            cameraFollowPosition.z = transform.position.z;
            
            Vector3 cameraMoveDirection = (cameraFollowPosition - transform.position).normalized;
            float distance = Vector3.Distance(cameraFollowPosition, transform.position);
            
            // Avoid overshooting the target
            if (distance > 0)
            {
                Vector3 newCameraPosition = transform.position + cameraMoveDirection * (speed * distance * Time.deltaTime);
                
                float distanceAfterMovement = Vector3.Distance(newCameraPosition, cameraFollowPosition);
                if (distanceAfterMovement > distance)
                {
                    // We have overshot the target
                    newCameraPosition = cameraFollowPosition;
                }
                
                transform.position = newCameraPosition;
            }
            
            
        }

        private void HandleZoom()
        {
            
        }
    }
}
