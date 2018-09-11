using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    
    public float speed = 0.3f;
    
    // Use this for initialization
    void Start () {
		
    }
	
    // Update is called once per frame
    void Update () {
        
	    Vector3 move = new Vector3();

        if (Input.GetKey(KeyCode.W)) 
            move.y += 1;
        if (Input.GetKey(KeyCode.S)) 
            move.y += -1;
        if (Input.GetKey(KeyCode.A)) 
            move.x += -1;
        if (Input.GetKey(KeyCode.D)) 
            move.x += 1;

        move.Normalize();

        transform.position += move * speed;
    }
}
