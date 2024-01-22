using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : PowerUpBase
{
    private TurretController turrentController;
    
    private void Awake()
    {
        if (!turrentController) turrentController = FindObjectOfType<TurretController>();
        PowerUpDuration = 2f;
    }
    protected override void OnHit()
    {
       
        PowerUp();
    }
    protected override void PowerUp()
    {
        Debug.Log("Cooldown Lowered");
        turrentController.FireCooldown = .25f;
        StartCoroutine(PowerUpTimer());
        
        
       
    }
    IEnumerator PowerUpTimer()
    {

        yield return new WaitForSeconds(PowerUpDuration);
        RevertCooldown();
    }
    void RevertCooldown()
    {
        turrentController.FireCooldown = .5f;
        Debug.Log("Cooldown Reverted");
    }
}
