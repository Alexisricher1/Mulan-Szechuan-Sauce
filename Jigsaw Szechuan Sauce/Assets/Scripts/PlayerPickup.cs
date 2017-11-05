using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public float throwForce = 100;
    private int playerNumber;

	void Start ()
    {
        playerNumber = GetComponentInParent<PlayerMovement>().playerNumber;
        Debug.Log("I AM : Joy" + playerNumber + "_AButton");
    }

    void Update()
    {
        if (Input.GetButtonDown("Joy" + playerNumber + "_AButton"))
        {
            Debug.Log("Joy" + playerNumber + "_AButton has been pressed!");
            if (GetComponentInChildren<Pickup>() != null)
            {
                var projectile = GetComponentInChildren<Pickup>();

                // On délaisse le projectile du joueur pour le mettre dans le root
                projectile.transform.parent = transform.root.parent;

                // COLLIDER
                var projectileCollider = projectile.GetComponent<SphereCollider>();
                projectileCollider.enabled = true;
                // Disable IsTrigger, comme ça, le pickup sait qu'il est maintenant un projectile
                projectileCollider.isTrigger = false;

                // RIGIDBODY
                var projectileRb = projectile.GetComponent<Rigidbody>();

                projectileRb.freezeRotation = false;
                projectileRb.constraints = RigidbodyConstraints.None;

                // Player1 shoot à droite (z), Player2 shoot à gauche
                projectileRb.AddForce(new Vector3(0, 0, (playerNumber == 1) ? throwForce : -throwForce));

                Debug.Log("Player : " + playerNumber + " is throwing something!");

            }
        }
    }
}
