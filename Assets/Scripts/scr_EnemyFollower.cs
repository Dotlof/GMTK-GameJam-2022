using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EnemyFollower : MonoBehaviour
{

    Vector3 direction; //= new Vector3(0,0,0);

    public Transform player;
    private Rigidbody2D rb;
    //private Vector2 movement;
    public float moveSpeed = 10f;
    public float repelRange = 10f;

    GameObject[] EnemyGameObjects;
    Transform[] Enemies;

    // Start is called before the first frame update
    void Start()
    {
        AssociateEnemyArray();
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        //movement = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.tag != "MeleeZone")
        {
            collision.gameObject.GetComponent<scr_Movement>().HP--;
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        MoveEnemy(direction);
        AssociateEnemyArray();
        Vector2 repelForce = Vector2.zero;

        foreach (Transform enemy in Enemies)
        {
            if (enemy != null)
            {
                if (Vector2.Distance(enemy.position, rb.position) <= repelRange)
                {
                    repelForce += (rb.position - (Vector2)enemy.position).normalized;
                }
            }
            Vector2 newPos = transform.position + (direction * moveSpeed * Time.deltaTime);
            newPos += repelForce * Time.deltaTime;
            rb.MovePosition(newPos);

        }

    }


    void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void AssociateEnemyArray()
    {
        int x = 0;
        EnemyGameObjects = new GameObject[GameObject.FindGameObjectsWithTag("Enemy").Length];
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            EnemyGameObjects[x] = enemy;
            x++;
        }
        Enemies = new Transform[EnemyGameObjects.Length];
        for (int i = 0; i < EnemyGameObjects.Length; i++)
        {
            Enemies[i] = EnemyGameObjects[i].GetComponent<Transform>();
            //Debug.Log(Enemies[i]);
        }
    }
}
