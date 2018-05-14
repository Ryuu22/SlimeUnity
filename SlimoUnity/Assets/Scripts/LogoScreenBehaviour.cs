using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScreenBehaviour : MonoBehaviour {

    // Use this for initialization
    public float fadeInTime;
    public float holdTime;
    public float fadeOutTime;



	void Start ()
    {
		
	}
	
	void Update ()
    {
		if (fadeInTime > 0)
        {
            fadeInTime -= Time.deltaTime;

        }
        else if(holdTime > 0)
        {
            holdTime -= Time.deltaTime;
        
        }
        else if(fadeOutTime > 0)
        {
            fadeOutTime -= Time.deltaTime;
        }
	}
}
