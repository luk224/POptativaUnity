using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorChange : MonoBehaviour {
    public GameObject go;
    Vector3 plus = new Vector3(0,1,0);

    Ray ray;
	void Start () {
        
        //var newObj = Instantiate(go,transform.position+plus,transform.rotation);
    }


	void Update () {
        if(Input.touchCount>0 )
        {
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Debug.DrawRay(ray.origin, ray.direction * 500);
            if (Physics.Raycast(ray,out hit))
            {
                
                Debug.Log("Hit something");
                Instantiate(go, hit.point  , transform.rotation);
            }
        }
        

        /*
        foreach ( Touch  touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                var ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray))
                {
                    // Create a particle if hit
                    Instantiate(go, transform.position + plus, transform.rotation);
                }
            }
        }
        */
    }
}
