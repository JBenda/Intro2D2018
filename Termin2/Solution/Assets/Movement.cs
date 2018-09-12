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
        bool up = Input.GetKey(KeyCode.W);
        bool down = Input.GetKey(KeyCode.S);
        bool left = Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.D);

        Vector3 mov = new Vector3(0, 0, 0);

        if (up && !down) mov.y = 1;
        if (down && !up) mov.y = -1;
        if (left && !right) mov.x = -1;
        if (right && !left) mov.x = 1;

        mov.Normalize();

        transform.position += mov * speed;
	}
}
