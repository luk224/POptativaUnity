using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour {

    float vel = 0.01f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void moveThisRight()
    {
        
        this.transform.Translate(vel, 0, 0);
    }
    public void moveThisLeft()
    {

        this.transform.Translate(-vel, 0, 0);
        
    }

   
}
