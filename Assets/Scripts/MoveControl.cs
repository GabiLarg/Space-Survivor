/*Gabriela Pereira de Assis
 * RedID 818592808
 *CS583 - 3D Game Programming
 *Assignment 5 */
using UnityEngine;
using System.Collections;

public class MoveControl : MonoBehaviour {


	//Script for the constant movement of the enemies or bullet
	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2 (0, 0.2f);
	private Vector2 movement;

	// Update is called once per frame
	void Update () {

		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
		
	}
	
	void FixedUpdate(){
		
		rigidbody2D.velocity = movement;
	}

}
