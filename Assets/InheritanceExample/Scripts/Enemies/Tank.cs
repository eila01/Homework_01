using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    protected override void OnHit()
    {
        // stop speed when hit
        StartCoroutine(SlowSpeed());

    }
    // Slow speed for 1 second,  then revert speed
    IEnumerator SlowSpeed()
    {
        MoveSpeed = 0;
        yield return new WaitForSeconds(1);
        revertSpeed();
    }
    // Revert speed function
    void revertSpeed()
    {
        MoveSpeed = .05f;
    }

}
