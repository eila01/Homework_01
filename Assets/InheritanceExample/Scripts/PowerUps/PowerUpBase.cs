using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class PowerUpBase : MonoBehaviour
{
    //[SerializeField] private int _health = 3;
    //[Header("FX")]
    //[SerializeField] private AudioClip _deathSound;
    //[SerializeField] private AudioClip _hitSound;
  //  [SerializeField] protected float MoveSpeed = .05f;
    [SerializeField] protected float PowerUpDuration = .05f;

    protected abstract void OnHit();
    protected abstract void PowerUp();

    protected Collider Col { get; private set; }

    private void Awake()
    {
        //RB = GetComponent<Rigidbody>();
        Col = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        //Move();
    }
    
    //protected virtual void Move()
    //{
    //    Vector3 moveDelta = transform.forward * MoveSpeed;
    //    RB.MovePosition(RB.position + moveDelta);
    //}

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            PowerUpDuration -= 0.01f;
            //_health -= 1;
           // AudioHelper.PlayClip2D(_hitSound, 1, .1f);
            OnHit();
            PowerUp();
            Col.enabled = false;
            transform.Find("Art").gameObject.SetActive(false);
            if (PowerUpDuration <= 0)
            {
                PowerDown();
            }
        }
    }
    
    public virtual void PowerDown()
    {
       // AudioHelper.PlayClip2D(_deathSound, 1, .1f);
        gameObject.SetActive(false);
    }
}
