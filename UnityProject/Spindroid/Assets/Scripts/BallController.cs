using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public GameObject player;

    Vector3 vel;
    float velocity = 0.01f;
	// Use this for initialization
	void Start () {
        vel = new Vector3(0, 0,0);
        this.transform.parent = player.transform;
        transform.localPosition = new Vector3(0, 2.5f, 0);


    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(vel);


    }

    public void Fire()
    {
        this.transform.parent = null;
        transform.rotation = new Quaternion(0, 0, 0,0);
        Vector3 direction = player.transform.up;
        Debug.Log(direction);
        direction.Normalize();
        vel =  direction * velocity;
        

    }

    float toRadians(float angle)
    {
        return (Mathf.PI / 180) * angle;
    }
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        float angle = Vector3.SignedAngle(contact.normal, -vel, Vector3.forward);
        float xprima = contact.normal.x * Mathf.Cos(toRadians(-angle)) - contact.normal.y * Mathf.Sin(toRadians(-angle));
        float yprima = contact.normal.x * Mathf.Sin(toRadians(-angle)) + contact.normal.y * Mathf.Cos(toRadians(-angle));
        Vector3 velprima = new Vector3(xprima, yprima, 0);
        velprima.Normalize();
        Debug.Log(angle);
        vel = velprima * velocity;
    }
    


}
