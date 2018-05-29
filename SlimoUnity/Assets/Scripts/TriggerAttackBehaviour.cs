using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttackBehaviour : MonoBehaviour {

    // Use this for initialization

    public float overAllTimeOff;
    public float timeLeft;
    void Start ()
    {
        timeLeft = overAllTimeOff;
	}

    private void Update()
    {
        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {

            Debug.Log("Time Done");
            timeLeft = overAllTimeOff;
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SlimeEnemy")
        {
            other.GetComponent<EnemyBehaviour>().SetDamage();
            this.gameObject.SetActive(false);
            Debug.Log("EnemyDetected");
        }
    }
}
