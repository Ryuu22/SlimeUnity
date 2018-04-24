using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    Vector2 axis;
    Rigidbody rb;
    [SerializeField]GameObject pointer;
    public Animator anim;

    public float savedEnergy;
    public bool savingEnergy;
    public float energyMultiplier;

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

        if (savingEnergy && savedEnergy < 1.0f)
        {
            savedEnergy += 0.1f;
        }
        else if (savingEnergy && savedEnergy > 1.0f)
        {
            savedEnergy = 1.0f;
        }

        anim.SetBool("SavingEnergy", savingEnergy);

    }
    void FixedUpdate()
    {
        rb.AddForce(new Vector3(axis.x * Time.deltaTime * speed, 0, axis.y * Time.deltaTime * speed),ForceMode.Impulse);
    }
    

    public void Move(Vector2 newAxis)
    {
        axis = newAxis;

    }
    public void Attack()
    {
        anim.SetTrigger("Attack");
    }
    public void JumpStart()
    {
        savingEnergy = true;
    }
    public void JumpEnd()
    {
        savingEnergy = false;
        rb.AddRelativeForce(Vector3.forward * savedEnergy * energyMultiplier);
        savedEnergy = 0;
    }
}
