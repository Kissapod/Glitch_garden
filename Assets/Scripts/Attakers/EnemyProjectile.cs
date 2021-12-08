using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed, damage;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Defenders defenders = collision.gameObject.GetComponent<Defenders>();
        Health health = collision.gameObject.GetComponent<Health>();

        if (defenders && health) 
        {
            health.DealDamage(damage); 
            Destroy(gameObject);
        }
    }
}
