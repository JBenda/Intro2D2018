using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseWASDController : AInputController
{

    public override bool IsShootDown()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public override bool IsUseItemDown()
    {
        return Input.GetKeyDown(KeyCode.LeftControl);
    }

    public override Vector2 GetMoveDir()
    {
        Vector2 result = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.A))
            result += new Vector2(1, 0);
        if (Input.GetKey(KeyCode.D))
            result += new Vector2(-1, 0);
        if (Input.GetKey(KeyCode.W))
            result += new Vector2(0, -1);
        if (Input.GetKey(KeyCode.S))
            result += new Vector2(0, 1);

        result.Normalize();
        return result;
    }

    public override Vector2 GetShootDir()
    {
        return transform.up;
    }
}
