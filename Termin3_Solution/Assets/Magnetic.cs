using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour
{

    [SerializeField]
    private float _force;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //--Vector from our position to our target--//
        Vector2 dir = collision.transform.position - transform.position;
        dir.Normalize();
        Rigidbody2D rgbd = collision.gameObject.GetComponent<Rigidbody2D>();

        //--Does our target have a rigidbody?--//
        if (rgbd)
        {
            //--Pull target--//
            if (Input.GetKey(KeyCode.Q))
            {
                rgbd.AddForce(dir * _force);
            }
            //--Push target--//
            if (Input.GetKey(KeyCode.E))
            {
                rgbd.AddForce(dir * _force * -1);
            }
        }
    }

}
