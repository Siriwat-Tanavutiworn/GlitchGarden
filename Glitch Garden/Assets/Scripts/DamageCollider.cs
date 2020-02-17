using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    HealthDisplay health;

   
    private void OnTriggerEnter2D(Collider2D otherCollision)
    {
            Destroy(otherCollision.gameObject);
            FindObjectOfType<HealthDisplay>().DecreaseHealth();
    }
}
