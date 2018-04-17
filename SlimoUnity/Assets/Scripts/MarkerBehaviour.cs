using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerBehaviour : MonoBehaviour {


    public void UpdatePosition(Vector3 newPosition)
    {
        this.transform.position = newPosition;
    }
}
