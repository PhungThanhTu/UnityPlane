using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    PlayerHealth health;
    Buffering buffering;

    private void Start()
    {
        health = GetComponentInParent<PlayerHealth>();
        buffering = GetComponentInParent<Buffering>();
    }

    public void TakeDamageAndBuffering(int damage)
    {
        health.TakeDamage(damage);
        buffering.StartBuffering();
    }

}
