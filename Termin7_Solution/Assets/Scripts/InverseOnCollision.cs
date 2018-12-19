using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseOnCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController ctrl = collision.gameObject.GetComponent<PlayerController>();
            if (ctrl != null)
            {
                AInputController inputCtrl = ctrl.GetInputController();
                if (inputCtrl != null)
                {
                    AInputController newCtrl = null;
                    if (inputCtrl is ArrowController)
                    {
                        newCtrl = collision.gameObject.GetComponent<InverseArrowController>() ??
                            collision.gameObject.AddComponent<InverseArrowController>();
                    }
                    else if (inputCtrl is InverseArrowController)
                    {
                        newCtrl = collision.gameObject.GetComponent<ArrowController>() ??
                            collision.gameObject.AddComponent<ArrowController>();
                    }
                    else if (inputCtrl is WASDController)
                    {
                        newCtrl = collision.gameObject.GetComponent<InverseWASDController>() ??
                            collision.gameObject.AddComponent<InverseWASDController>();
                    }
                    else if (inputCtrl is InverseWASDController)
                    {
                        newCtrl = collision.gameObject.GetComponent<WASDController>() ??
                            collision.gameObject.AddComponent<WASDController>();
                    }

                    if (newCtrl != null)
                        ctrl.SetInputController(newCtrl);
                }
            }

            Destroy(gameObject);
        }
    }
}
