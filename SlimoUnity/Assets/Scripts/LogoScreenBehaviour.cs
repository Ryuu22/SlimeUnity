using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScreenBehaviour : MonoBehaviour {

    // Use this for initialization
    public float fadeInTime;
    public float holdTime;
    public float fadeOutTime;

    public SpriteRenderer logo;
    public float alphaValue;

	
	void Update ()
    {
        logo.color = new Color(1, 1, 1, alphaValue);
        
		if (fadeInTime > 0)
        {
            fadeInTime -= Time.deltaTime;

            alphaValue = 3.0f - fadeInTime;
        }
        else if(holdTime > 0)
        {
            holdTime -= Time.deltaTime;
            alphaValue = 1;
        }
        else if(fadeOutTime > 0)
        {
            fadeOutTime -= Time.deltaTime;
            alphaValue = fadeOutTime;
        }
        else
        {
            SceneManager.LoadScene("Title");
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Logo");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Title");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Gameplay");
        }

    }
}
