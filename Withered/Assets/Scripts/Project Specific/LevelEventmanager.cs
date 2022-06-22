using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelEventmanager : Module
{
    public Action<Vector3> moving;

    public void Moving(Vector3 direction)
    {
        if(moving != null)
        {
            moving(direction);
        }
    }
}
