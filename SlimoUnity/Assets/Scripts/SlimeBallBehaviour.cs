using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBallBehaviour : MonoBehaviour {

    public Rigidbody rb;
    public Transform player;

    public bool free;

    private void Update()
    {
        if(!free)
        {
            this.transform.position = new Vector3(player.position.x, this.transform.position.y,player.position.z);
        }
    }

    public void GetShot(Vector3 inputForce)
    {
        rb.AddForce(inputForce, ForceMode.Impulse);
        free = true;
    }
    public void ComeBack()
    {
        rb.velocity = Vector3.zero;
        free = false;
    }
    

}
