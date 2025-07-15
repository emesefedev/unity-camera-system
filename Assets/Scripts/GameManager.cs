using Emesefe;
using UnityEngine;
using Emesefe.MonoBehaviours;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private PlayerCharacter player;
    [SerializeField] private PlayerCharacter player2;

    private void Start()
    {
        cameraFollow.Setup(() => player.transform.position);

        EmesefeDebug.ButtonUI(new Vector2(850, 400), "Player", () =>
        {
            cameraFollow.SetGetCameraFollowPositionFunc(() => player.transform.position);
        }, Color.gray);
        
        EmesefeDebug.ButtonUI(new Vector2(850, 300), "Player 2", () =>
        {
            cameraFollow.SetGetCameraFollowPositionFunc(() => player2.transform.position);
        }, Color.gray);
    }
    
}
