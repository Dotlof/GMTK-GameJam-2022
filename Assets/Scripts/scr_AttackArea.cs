using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AttackArea : MonoBehaviour
{
    private int damage = 20;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<scr_Health>() != null)
        {
            scr_Health health = collider.GetComponent<scr_Health>();
            health.Damage(damage);
        }
    }


}
