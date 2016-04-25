/*Gabriela Pereira de Assis
 * RedID 818592808
 *CS583 - 3D Game Programming
 *Assignment 5 */
using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	//1- HP-The enemy has 1 of health points
	public int hp = 1;

	public bool isEnemy = true;

	//1.1 HP - Takes the hp is the method is called	
	public void Damage(int damageCount){
		hp -= damageCount;
		if (hp <= 0) {	
			EnemyDeathSound();
			Destroy(gameObject);
		}
	}	
	//2 - Collision - Destroy the enemy if it collides
	void OnTriggerEnter2D(Collider2D otherCollider){
		//Calls Damage is collides  with the spaceShip or the limits of the screen
		if (otherCollider.gameObject.name == "sky" | otherCollider.gameObject.name =="Spaceship") {
			Damage (hp);
			//takes 3 seconds from game time
			GameController.SubTime();
		} else {
			BulletScript bullet = otherCollider.gameObject.GetComponent<BulletScript> ();

			//get the object and checks is it came from the enemy or the player
			if (bullet != null) {
				if (bullet.isEnemyShot != isEnemy) {
					GameController.AddScore();
					GameController.AddTime();
					Damage (bullet.damage);
					Destroy (bullet.gameObject);
				}
			}

		}
	}
	//3-Plays the death song
	void EnemyDeathSound(){
		GameObject audioObjetc = GameObject.Find ("EnemyDeathSound");
		if (audioObjetc != null) {
			AudioSource audio = audioObjetc.GetComponent<AudioSource>();
			if(audio!= null){
				audio.Play();
			}
		}
	}
	
}
