using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

// MUST add abstract keyword to any class that contains an abstract method
public abstract class EnemyBase : MonoBehaviour
{
    /*
     * Inheritance:
     * (Base Class)
     *  - Virtual: ALLOW this method to be overriden
     *  - Abstract: Require this method to be overridden, and defined in the inheriting class.
     *  (Derived Class)
     *  - Override: Add functionalityto either a virtual or abstract method defined in the parent class.
     */
    /*
     * ANY class can modify health if its public
     * publc int Health = 3;
     */
    // Only this class can modify health
    [SerializeField] private int _health = 3;
    [Header("FX")]
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] protected float MoveSpeed = .05f; // All Enemies to have MoveSpeed

    // Abstract = incomplete, never defined
    protected abstract void OnHit(); // undefined method that only child objects can define
    // protected allows child classes access to variables and method, but not only classes
    protected Rigidbody RB { get; private set; }

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    // child classes have the ability to run Move(), but other classes do not
    // Base Inheritance Example
    protected virtual void Move()
    {
        // Allows enemies to move in a straight forward but can be modified to specifc child classes
        Vector3 moveDelta = transform.forward * MoveSpeed;
        RB.MovePosition(RB.position + moveDelta);
    }

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            _health -= 1;
            AudioHelper.PlayClip2D(_hitSound, 1, .1f);
            OnHit();
            if (_health <= 0)
            {
                Kill();
            }
        }
    }
    // ANYTHING can call Kill() function. 
    // Want the child class to modify when a enemy dies that could spawn power ups or spawn more enemies.
    public virtual void Kill()
    {
        AudioHelper.PlayClip2D(_deathSound, 1, .1f);
        gameObject.SetActive(false);
    }
}
