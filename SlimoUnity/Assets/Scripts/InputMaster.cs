using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMaster : MonoBehaviour {

    PlayerBehaviour playerBeh;
    Vector2 axis;
    public MarkerBehaviour marker;
    


    private void Start()
    {
        playerBeh = GetComponent<PlayerBehaviour>();
    }
    void Update ()
    {
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");

        playerBeh.Move(axis);


    #region Raycasting
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if(hit.transform.tag == "Floor")
            {
                marker.UpdatePosition(hit.point);
            }
            
        }
        #endregion

    #region Attacking

        if(Input.GetButton("Fire1"))
        {
            playerBeh.Attack();
        }

        if(Input.GetButton("Fire2"))
        {
            playerBeh.JumpStart();
        }
        if(Input.GetButtonUp("Fire2"))
        {
            playerBeh.JumpEnd();
        }

    #endregion

    }
}
