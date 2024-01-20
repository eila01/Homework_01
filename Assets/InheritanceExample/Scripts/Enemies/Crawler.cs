using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crawler : EnemyBase
{
    // replace abstract w/ override to define the method
    protected override void OnHit()
    {
        
    }
    /*
    protected override void Move()
    {
        // Change movement 
    }*/

    public override void Kill()
    {
        //TODO put code you want to happen before disable here

        // this runs the base method AND what's above it here
        base.Kill(); // w/out base.Kill(), the base method will be override and do nothing
    }
}
