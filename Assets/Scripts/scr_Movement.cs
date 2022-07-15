using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Movement : MonoBehaviour
{
    public int HP = 6;

    public scr_WeaponSystem[] WeaponSystems;
    private int currentWeaponSystemIndex = 0;

    public float moveSpeed;
    private Vector3 direction;

    public string fireDirection;

    private GameObject attackAreaUp;
    private GameObject attackAreaDown;
    private GameObject attackAreaLeft;
    private GameObject attackAreaRight;
    private bool attacking = false;
    private float timeToAttack = 0.1f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
        attackAreaUp = transform.GetChild(0).gameObject;
        attackAreaDown = transform.GetChild(1).gameObject;
        attackAreaLeft = transform.GetChild(2).gameObject;
        attackAreaRight = transform.GetChild(3).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP > 6) HP = 6;
        if(HP <= 0)
        {
            Debug.Log("Player Died");
            HP = 0;
        }
        currentWeaponSystemIndex = HP - 1;

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if(direction.x != 0 && direction.y != 0)
        {
            //SQRT 2
            transform.position += direction * moveSpeed / Mathf.Sqrt(2);
        }

        else transform.position += direction * moveSpeed;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            fireDirection = "up";
            FireWeapon();
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            fireDirection = "down";
            FireWeapon();
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            fireDirection = "left";
            FireWeapon();
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            fireDirection = "right";
            FireWeapon();
        }

        if (attacking)
        {
            timer += Time.deltaTime;   
            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackAreaUp.SetActive(attacking); attackAreaDown.SetActive(attacking); attackAreaRight.SetActive(attacking); attackAreaLeft.SetActive(attacking);
            }
        }

    }

    void MeleeAttack()
    {
        attacking = true;
        switch (fireDirection)
        {
            case "up":
                attackAreaUp.SetActive(attacking);
                break;
            case "down":
                attackAreaDown.SetActive(attacking);
                break;
            case "left":
                attackAreaLeft.SetActive(attacking);
                break;
            case "right":
                attackAreaRight.SetActive(attacking);
                break;
        }
    }

    void FireWeapon()
    {
        if (HP != 6) WeaponSystems[currentWeaponSystemIndex].Fire();
        else MeleeAttack();
    }

    private void FixedUpdate()
    {
        
    }
}
