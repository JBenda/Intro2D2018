using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjChanger : MonoBehaviour {

    [SerializeField]
    private GameObject targetObj;

    public GameObject targetObj2;
    public PlayerMovement player;
    public int a;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            Debug.Log("collision with player");
            if (targetObj.activeInHierarchy)
            {
                Debug.Log("Deactivate");
                targetObj.SetActive(false);
            }
            else
            {
                Debug.Log("Activate");
                targetObj.SetActive(true);
            }
        }
    }
}
