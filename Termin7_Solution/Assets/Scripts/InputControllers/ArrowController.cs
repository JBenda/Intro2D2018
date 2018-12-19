using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : AInputController
{
    public override bool IsShootDown()
    {
        return Input.GetKeyDown(KeyCode.L);
    }

    public override bool IsUseItemDown()
    {
        return Input.GetKeyDown(KeyCode.K);
    }

    public override Vector2 GetMoveDir()
    {
        Vector2 result = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            result += new Vector2(-1, 0);
        if (Input.GetKey(KeyCode.RightArrow))
            result += new Vector2(1, 0);
        if (Input.GetKey(KeyCode.UpArrow))
            result += new Vector2(0, 1);
        if (Input.GetKey(KeyCode.DownArrow))
            result += new Vector2(0, -1);

        result.Normalize();
        return result;
    }

    public override Vector2 GetShootDir()
    {
        return transform.up;
    }
}
