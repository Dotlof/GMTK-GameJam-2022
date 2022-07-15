using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ShootingEnemy : MonoBehaviour
{
    public scr_WeaponSystem WeaponSystem;
    Vector3 target;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationModifier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 direction = target - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        WeaponSystem.Fire();
    }

}
