using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour {
    public GameObject parent;
    float vel = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void moveThisRight()
    {
        
        //this.transform.Translate(vel, 0, 0);
        parent.transform.Rotate(0, 0, -vel);
        
    }
    public void moveThisLeft()
    {
        parent.transform.Rotate(0, 0, vel);
        //this.transform.Translate(-vel, 0, 0);
        
    }

   
}
