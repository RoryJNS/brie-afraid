using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
    }
}