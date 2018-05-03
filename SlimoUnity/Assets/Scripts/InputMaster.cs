using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMaster : MonoBehaviour {

    PlayerBehaviour playerBeh;
    public SlimeBallBehaviour slimeBall;
    Vector2 axis;
    public MarkerBehaviour marker;

    public bool ShootingMode;

    


    private void Start()
    {
        playerBeh = GetComponent<PlayerBehaviour>();
        ShootingMode = false;
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

        if(Input.GetKeyDown(KeyCode.E))
        {
            slimeBall.ComeBack();
            ShootingMode = !ShootingMode;
        }

        if(Input.GetButtonDown("Fire1") && !ShootingMode)
        {
            playerBeh.Attack();

        }
        if (Input.GetButtonDown("Fire1") && ShootingMode)
        {
            playerBeh.Shoot();
            ShootingMode = false;
        }

        if (Input.GetButtonDown("Fire2") && !ShootingMode)
        {
            playerBeh.JumpStart();
        }
        if(Input.GetButtonUp("Fire2") && !ShootingMode)
        {
            playerBeh.JumpEnd();
        }


    #endregion

    }
}
