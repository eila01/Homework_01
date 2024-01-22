using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class PowerUpBase : MonoBehaviour
{
    
    [SerializeField] protected float PowerUpDuration = .05f;

    protected abstract void OnHit();
    protected abstract void PowerUp();

    protected Collider Col { get; private set; }

    private void Awake()
    {
       
        Col = GetComponent<Collider>();
    }

    
    
    

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            
            OnHit();
            
           // Col.enabled = false;
            transform.Find("Art").gameObject.SetActive(false);
            if (PowerUpDuration <= 0)
            {
                PowerDown();
            }
        }
    }
    
    public virtual void PowerDown()
    {
       
        gameObject.SetActive(false);
    }
}
