/*Gabriela Pereira de Assis
 * RedID 818592808
 *CS583 - 3D Game Programming
 *Assignment 5 */
using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {
	
	//movement values	
	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction;
	private Vector2 movement;

		void Start () {
		//move ramdomicaly
		direction = new Vector2 (Random.Range(-0.3f, 0.3f), -0.2f);
	}
	
	//shot values
	private BulletTrigger bullet;
	
	//initialize a the shot trigger
	void Awake(){
		bullet = GetComponent<BulletTrigger>();
	}
	//moves and shoot each frame
	void Update () {
		
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);

		if (bullet != null) {
			bullet.Attack(true);
		}
		
	}
	
	void FixedUpdate(){
		
		rigidbody2D.velocity = movement;
	}


}
