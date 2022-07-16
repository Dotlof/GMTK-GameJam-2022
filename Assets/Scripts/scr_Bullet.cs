using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Bullet : MonoBehaviour
{
    public string shootingDirection; 

    public float range; //in Seconds
    public Rigidbody2D rb;
    public float speed;
    public int damage;

     public bool isEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && isEnemy != true) collision.gameObject.GetComponent<scr_Health>().Damage(damage);
        if (collision.gameObject.tag == "Player" && isEnemy == true) collision.gameObject.GetComponent<scr_Movement>().HP--;
        if (collision.gameObject.tag == "Wall") Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        shootingDirection = GameObject.FindGameObjectWithTag("Player").GetComponent<scr_Movement>().fireDirection;

        //Missing Logic for Direction
        if (shootingDirection == "up" && isEnemy != true) rb.AddRelativeForce(new Vector2(0, speed), ForceMode2D.Impulse);
        else if (shootingDirection == "down" && isEnemy != true) rb.AddRelativeForce(new Vector2(0, -speed), ForceMode2D.Impulse);
        else if (shootingDirection == "left" && isEnemy != true) rb.AddRelativeForce(new Vector2(-speed, 0), ForceMode2D.Impulse);
        else if (shootingDirection == "right" && isEnemy != true) rb.AddRelativeForce(new Vector2(speed, 0), ForceMode2D.Impulse);
        else if (isEnemy) rb.AddRelativeForce(new Vector2(-speed, 0), ForceMode2D.Impulse);
        Destroy(gameObject, range);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void MoveBullet(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

}
