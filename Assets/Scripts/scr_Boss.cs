using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Boss : MonoBehaviour
{

    public scr_WeaponSystem WeaponSystem;
    [SerializeField] private float speed = 10f;
    private Vector2 direction;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") speed = speed * -1;
        if (collision.gameObject.tag == "Player") GetComponent<scr_Movement>().HP--;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = speed;
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        WeaponSystem.Fire();
    }
}
