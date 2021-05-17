using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
	public float startTimeBtwAttack;
	public Transform attackPos;
	public float attackRange;
	public LayerMask whatIsEnemies;
	public int damage;
	public Animator animator;
	public float attacking;
	
	void Start()
	{
		attacking = 0f;	
	}
	
	void Update(){

		
		if (animator.GetBool("RightAttack") || animator.GetBool("LeftAttack") || animator.GetBool("UpAttack") || animator.GetBool("DownAttack"))
		{
			attacking += Time.deltaTime;
			
			/*
			Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
			for (int i = 0; i < enemiesToDamage.Length; i++)
			{
				enemiesToDamage[i].GetComponent<EnemyHealth>().health -= damage;
				Debug.Log("attacked");
			}*/
			
		}
		
		if (attacking >= 0.4f)
		{
			animator.SetBool("RightAttack", false);
			animator.SetBool("LeftAttack", false);
			animator.SetBool("DownAttack", false);
			animator.SetBool("UpAttack", false);
			
			attacking = 0f;
			GetComponent<PlayerMovement>().setActive(true);
			
			/*
			Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
			for (int i = 0; i < enemiesToDamage.Length; i++)
			{
				enemiesToDamage[i].GetComponent<EnemyHealth>().health -= damage;
				Debug.Log("attacked");
			}*/
		}
		
		if (timeBtwAttack <= 0){
			if (Input.GetMouseButtonDown(0) && GetComponent<PlayerMovement>().getActive())
			{
				if (GetComponent<PlayerMovement>().getLastMoveDirection() == "R")
					animator.SetBool("RightAttack", true);
				else if (GetComponent<PlayerMovement>().getLastMoveDirection() == "L")
					animator.SetBool("LeftAttack", true);
				else if (GetComponent<PlayerMovement>().getLastMoveDirection() == "U")
					animator.SetBool("UpAttack", true);
				else if (GetComponent<PlayerMovement>().getLastMoveDirection() == "D")
					animator.SetBool("DownAttack", true);
				
				
				GetComponent<PlayerMovement>().setActive(false);
				Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
				for (int i = 0; i < enemiesToDamage.Length; i++)
				{
					enemiesToDamage[i].GetComponent<EnemyHealth>().currentHealth -= damage;
					Debug.Log("attacked");
				}
			}
			
		} else {
			timeBtwAttack -= Time.deltaTime;
		}
	}
	
	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackPos.position, attackRange);
	}
}
