using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    Vector2 axis;
    Rigidbody rb;
    [SerializeField]GameObject pointer;

    public float speed;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.LookAt(pointer.transform.position);
    }
    void FixedUpdate()
    {
        rb.AddForce(new Vector3(axis.x * Time.deltaTime * speed, 0, axis.y * Time.deltaTime * speed),ForceMode.Impulse);
    }
    

    public void Move(Vector2 newAxis)
    {
        axis = newAxis;

    }


}
