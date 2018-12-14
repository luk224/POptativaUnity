using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public GameObject parent_Player;
    public GameObject player;
    Vector3 velRecovery;
    Vector3 vel;
    public float initialVelocity = 0.01f;
    float velocity = 0.01f;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(vel);


    }

    public void Fire()
    {
        if (transform.parent == parent_Player.transform)
        {
            transform.parent = WorldController.getWorldController().gameRoot.transform;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            Vector3 direction = parent_Player.transform.position- player.transform.position;
            direction.Normalize();
            velocity = initialVelocity + (WorldController.getWorldController().numLevel) * 0.0025f;
            vel = direction * velocity;
        }
        
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "border_collision")
        {
            resetBall();
            WorldController.getWorldController().loseLife();    
        }
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
        vel = velprima * velocity;

        if(collision.gameObject.tag == "brick")
        {
            WorldController.getWorldController().hitBrick(collision.gameObject.GetComponent<Brick>());
        }
    }

    public void resetBall()
    {
        vel = Vector3.zero;
        transform.parent = parent_Player.transform;
        transform.localPosition = new Vector3(0, player.transform.localPosition.y + 0.15f, 0);
    }
    
    public void pause() {
        velRecovery = new Vector3(vel.x, vel.y, vel.z);
        vel = Vector3.zero;
    }

    public void unpause()
    {
        vel = velRecovery;
    }



}
