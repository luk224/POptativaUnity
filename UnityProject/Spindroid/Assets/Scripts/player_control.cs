using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour {
  
    public float acceleration = 0.08f;
    public float decceleration = 0.1f;
    public float maxSpeed = 3.0f;

    private float curSpeed = 0.0f;
    public float factorChangeVel = 0.75f;

    private bool movingRight = false;
    private bool movingLeft = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, -curSpeed);


        if (movingLeft)
        {
            if(!(curSpeed < -maxSpeed))
            {
                if (curSpeed > 0)
                    curSpeed *= factorChangeVel;
                curSpeed -= acceleration;
            }
            

        }
        if (movingRight)
        {
            if (!(curSpeed > maxSpeed))
            {
                if (curSpeed < 0)
                    curSpeed *= factorChangeVel;
                curSpeed += acceleration;
                if (movingLeft)
                {
                    curSpeed = 0;
                }
            }

        }
        if(!(movingRight || movingLeft))//No se pulsa nada:
        {


            deccelerate();
        }

       
            
            
        
    }
    private void deccelerate()
    {


        if (curSpeed > 0f)
        {
            curSpeed -= decceleration;
        }

        else if (curSpeed < 0f)
        {
            curSpeed += decceleration;
        }

        if (curSpeed > -decceleration && curSpeed < decceleration)
        {
            curSpeed = 0;
        }
    }

    public void moveThisRight()
    {
        movingRight = true;

       
        //this.transform.Translate(vel, 0, 0);
       
        
    }
    public void moveThisLeft()
    {
        movingLeft = true;
        
        
        
        //this.transform.Translate(-vel, 0, 0);
        
    }

    public void notMoveThisLeft()
    {
        movingLeft = false;
    }

     public void notMoveThisRight()
    {
        movingRight = false;
    }
    
    public void notMove()
    {
        movingRight = false;
        movingLeft = false;
    }
}
