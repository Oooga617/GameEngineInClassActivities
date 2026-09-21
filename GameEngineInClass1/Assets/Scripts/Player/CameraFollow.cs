using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    private CameraFollow camFollow;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        camFollow = GetComponent<CameraFollow>();
        if (player ==null)
        {
            camFollow.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //makes the camera follow the x position of the player
    private void LateUpdate()
    {
        Vector3 newPos = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
        this.transform.position = newPos;
    }
}
