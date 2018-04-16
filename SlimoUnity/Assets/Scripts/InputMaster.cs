using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMaster : MonoBehaviour {

    PlayerBehaviour playerBeh;
    Vector2 axis;

    private void Start()
    {
        playerBeh = GetComponent<PlayerBehaviour>();
    }
    void Update ()
    {
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");

        playerBeh.Move(axis);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100, 8))
            Debug.DrawLine(ray.origin, hit.point);

        playerBeh.UpdateDirection(hit.point);

    }
}
