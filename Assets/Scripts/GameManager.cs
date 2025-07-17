using Emesefe;
using UnityEngine;
using Emesefe.MonoBehaviours;
using Emesefe.Utilities;
using UnityEngine.Serialization;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private PlayerCharacter player;
    [SerializeField] private PlayerCharacter player2;

    private Vector3 cameraFollowPosition;
    
    private float zoom = 20f;
    private float zoomStep = 10f;
    private float zoomMin = 10f;
    private float zoomMax = 100f;

    [SerializeField] private bool enabledEdgeScrolling;
    private float edgeSize = 20f; // 20 pixels
    private float moveAmount = 20f;

    private void Start()
    {
        cameraFollow.Setup(() => cameraFollowPosition, () => zoom);
    }

    private void Update()
    {
        HandleEdgeScrolling();
    }

    private void HandleEdgeScrolling()
    {
        if (!enabledEdgeScrolling) return;
        
        if (Input.mousePosition.x > Screen.width - edgeSize)
        {
            cameraFollowPosition.x += moveAmount * Time.deltaTime;
        }
        
        if (Input.mousePosition.x < edgeSize)
        {
            cameraFollowPosition.x -= moveAmount * Time.deltaTime;
        }
        
        if (Input.mousePosition.y > Screen.height - edgeSize)
        {
            cameraFollowPosition.y += moveAmount * Time.deltaTime;
        }
        
        if (Input.mousePosition.y < edgeSize)
        {
            cameraFollowPosition.y -= moveAmount * Time.deltaTime;
        }
    }

    private void ZoomIn()
    {
        zoom -= zoomStep;
        if (zoom < zoomMin)
        {
            zoom = zoomMin;
        }
    }
    
    private void ZoomOut()
    {
        zoom += zoomStep;
        if (zoom > zoomMax)
        {
            zoom = zoomMax;
        }
    }
    
}
