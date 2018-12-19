using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadController : AInputController
{
    private bool _shotPressed = false;

    public override Vector2 GetMoveDir()
    {
        Vector2 stick = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (stick != Vector2.zero)
            stick.Normalize();
        return stick;
    }

    public override Vector2 GetShootDir()
    {
        Vector2 stick = new Vector2(Input.GetAxis("HorizontalRight"), Input.GetAxis("VerticalRight"));
        if (stick != Vector2.zero)
            stick.Normalize();
        return stick;
    }

    public override bool IsShootDown()
    {
        if (Input.GetAxis("Fire1") < 0)
            if (!_shotPressed)
                return _shotPressed = true;
            else
                return false;
        else
            return (_shotPressed = false);
    }

    public override bool IsUseItemDown()
    {
        return Input.GetButtonDown("Fire2");
    }
}
