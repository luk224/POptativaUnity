using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    int health;
    public List<Material> materials = new List<Material>();
    // Use this for initialization
    void Start () {
        health = materials.Count;
        GetComponent<Renderer>().material = materials[health-1];

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void hit()
    {
        if(health == 1)
        {
            Destroy(gameObject);
            WorldController.getWorldController().numBricks--;
        }
        else
        {

            health--;
            GetComponent<Renderer>().material = materials[health-1];

        }

    }


}
