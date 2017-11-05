using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeWall : MonoBehaviour
{
    // Change le déplacement 
    public bool isLeftWall;
    public int damage = 20;
    public float damageCooldownSeconds = 0.3f;
    public float bounceForce = 5f;

    private bool isCoolingDown = false;

    private void Update()
    {
        Vector3 translateVector = isLeftWall ? Vector3.right : Vector3.left;
        transform.Translate(translateVector * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !isCoolingDown)
        {
            var hitPlayerAttributes = collision.gameObject.GetComponent<PlayerAttributes>();
            hitPlayerAttributes.GetHit(damage);

            // Bounce
            Debug.Log(collision.gameObject.GetComponent<Rigidbody>() != null);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(isLeftWall ? Vector3.right : Vector3.left * bounceForce);
            StartCoroutine(CoolingDown(damageCooldownSeconds));
        }
    }

    public IEnumerator CoolingDown(float seconds)
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(seconds);
        isCoolingDown = false;
    }
}
