using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Health : MonoBehaviour
{
    [SerializeField] private int health;

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int amount)
    {
        this.health -= amount;
    }
}
