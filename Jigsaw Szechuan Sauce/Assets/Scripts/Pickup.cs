using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class Pickup : MonoBehaviour
{
    public int damage;

    private SphereCollider sc;
    private Rigidbody rb;
    private bool hasHitPlayerOnce;

    void Start ()
    {
        sc = GetComponent<SphereCollider>();
        sc.isTrigger = true;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    /// <summary>
    /// Le pickup est en mode pickup lorsqu'il est un trigger
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            var player = collider.gameObject;
            if (player.GetComponentInChildren<PlayerPickup>().GetComponentInChildren<Pickup>() == null)
            {
                this.gameObject.GetComponent<SphereCollider>().enabled = false;

                var duplicatePickup = gameObject;

                // Player pickup
                var playerPickup = player.GetComponentInChildren<PlayerPickup>();

                duplicatePickup.transform.parent = playerPickup.transform;

                // Position 0
                duplicatePickup.transform.localPosition = Vector3.zero;
            }
        }
    }

    /// <summary>
    /// Le pickup est un projectile lorsqu'il est un collider
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !hasHitPlayerOnce)
        {
            var hitPlayerAttributes = collision.gameObject.GetComponent<PlayerAttributes>();
            hitPlayerAttributes.GetHit(damage);
            hasHitPlayerOnce = true;
        }
        Destroy(gameObject, 2.0f);
    }
}
