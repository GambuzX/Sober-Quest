using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public float cameraTopLimit = -0.6f;
    public float cameraBelowLimit = -0.82f;
    public float cameraRightLimit = 6.4f;
    public float cameraLeftLimit = -6.22f;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 newPos = new Vector3(playerPos.x, playerPos.y, -10);
        if (newPos.y < cameraBelowLimit) newPos.y = cameraBelowLimit;
        if (newPos.y > cameraTopLimit) newPos.y = cameraTopLimit;
        if (newPos.x < cameraLeftLimit) newPos.x = cameraLeftLimit;
        if (newPos.x > cameraRightLimit) newPos.x = cameraRightLimit;

        this.transform.position = newPos;
    }
}
