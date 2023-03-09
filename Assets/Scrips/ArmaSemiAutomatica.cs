using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaSemiAutomatica : Arma {

    protected override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Disparar();
        }
        base.Update();
    }
}
