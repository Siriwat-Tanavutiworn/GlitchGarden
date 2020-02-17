using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [Range(0f, 5f)]
    [SerializeField] float currentMoveSpeed = 1f;

    [SerializeField] float damage = 100f;
    


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * currentMoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>();
        var attacker = other.GetComponent<Attacker>();

        if(attacker && health)
        {
            health.DamageDealer(damage);
            Destroy(gameObject);
        }        
    }

}
