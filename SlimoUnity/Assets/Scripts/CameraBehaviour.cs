using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public Transform player;
    Vector3 currentPosition;
    Vector3 flashPosition;
    public float freq;
    public float marginZ;


    // Update is called once per frame
    void Update()
    {
        currentPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        flashPosition = player.position;
        flashPosition.y = currentPosition.y;
        flashPosition.z = flashPosition.z - marginZ;

        this.transform.position = Vector3.Lerp(currentPosition, flashPosition, freq);

    }
}
