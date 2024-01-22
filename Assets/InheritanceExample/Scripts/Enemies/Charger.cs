using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : EnemyBase
{
    public Transform Spawnpoint;
    public GameObject prefab;
    protected override void OnHit()
    {
        // increase speed when hit
        MoveSpeed *= 2;
    }

    public override void Kill()
    {
        Spawn();
        base.Kill(); 
    }
    public void Spawn()
    {
        Instantiate(prefab, Spawnpoint.position, Spawnpoint.rotation);

    }
}
