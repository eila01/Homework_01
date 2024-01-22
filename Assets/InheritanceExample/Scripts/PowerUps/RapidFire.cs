using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : PowerUpBase
{
    [SerializeField] private TurretController turrentController;
    // private float _cooldown = TurretController.FireCooldown;
    private void Awake()
    {
        if (!turrentController) turrentController = GetComponent<TurretController>();
    }
    protected override void OnHit()
    {

    }
    protected override void PowerUp()
    {
        turrentController.FireCooldown = .25f;
    }
}
