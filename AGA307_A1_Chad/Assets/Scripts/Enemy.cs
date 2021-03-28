using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveDistance = 200;
    public float moveSpeed = 10;

    public EnemyType myType;
    public float health;

    public Animator anim;
    

    void Start()
    {
        anim = this.GetComponent<Animator>();
        SetUp();
        StartCoroutine(Move());
        
    }

    void SetUp()
    {
        switch(myType)
        {
            case EnemyType.Ranged:
                health = 50;
                break;
            case EnemyType.Light:
                health = 100;
                break;
            case EnemyType.Heavy:
                health = 200;
                break;
        }
    }

    void Update()
    {      
        if (Input.GetKeyDown("k"))
            Die();
                

        /*
         if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("ChangeAnimation");
            //anim.SetBool("useSpin", !anim.GetBool("useSpin"));
        }
        // */
    }

    IEnumerator Move()
    {
        if(anim)
            anim.SetFloat("Speed", moveSpeed);
        for (int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            yield return null;            
        }

        //changes enemy move direction to random number between 0 - 360
        transform.Rotate(Vector3.up * (Random.Range(0, 360)));

        if(anim)
        anim.SetFloat("Speed", 0);
        yield return new WaitForSeconds(3);

        StartCoroutine(Move());
        
    }

    public enum EnemyType
        {
            Light,
            Heavy,
            Ranged
        }

    /*void Die()
    {
        //GameManage.instance.enemiesKilled++;
        GameManage.instance.AddScore(50);
        //EnemyManager.instance.OnEnemyKilled(this.gameObject);
        this.gameObject.SetActive(false);
    }*/

    public void TakeDamage(float amount)
    {
        anim.SetTrigger("Hit");
        health -= amount;
        GameManage.instance.AddScore(10);
        if (health <= 0f)
        {
            Die();
        }
            
    }

    void Die()
    {
        anim.SetTrigger("Die");
        GameManage.instance.AddScore(100);
        //EnemyManager.instance.EnemyKilled(gameObject);
        StopAllCoroutines();
        Destroy(this.gameObject);
    }


}
