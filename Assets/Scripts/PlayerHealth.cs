/*Gabriela Pereira de Assis
 * RedID 818592808
 *CS583 - 3D Game Programming
 *Assignment 5 */
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	private int hp = 10;
	public static int publichp;
	public bool isEnemy = false;
	public int points = 1000;

	void Update () {
		// 1 - Extra Hp for each 100 poits
		if(GameController.score>=points){
			hp+=2;
			points +=1000;
		}

		//2- End of time end of game
		if (GameController.timeRemaining <= 0) {
			Damage(hp);
		}
		//updates the public hp to show on screen
		publichp = hp;
	}

	//3- Takes the hp acording the value received
	public void Damage(int damageCount){
		//play the sound for each hit
		PlayHitSound ();
		hp -= damageCount;
		if (hp <= 0) {	//checks the death
			PlayerDeathSound();
			System.Threading.Thread.Sleep(1100);//Pauses the game for 1.1 seconds 	
			Destroy(gameObject);//destroy it
		}

	}	
	//4 - Collision
	void OnTriggerEnter2D(Collider2D otherCollider){

		//if collides with the UFO or the bullet call Damage function
		if (otherCollider.gameObject.tag =="Enemy") {
			Damage (1);
		} else {

			BulletScript bullet = otherCollider.gameObject.GetComponent<BulletScript> ();
			//if bullet is different of null than it hits a bullet			
			if (bullet != null) {
				//checks if the bullet came from the enemy
				if (bullet.isEnemyShot != isEnemy) {
					GameController.SubScore(); //subtracts 50 points from score
					GameController.SubTime(); //subtracts 3 seconds of the time
					Damage (bullet.damage); //gaves the bullet demage
					Destroy (bullet.gameObject); //distroies the bullet
				}
			}
			
		}
	}

	//5- Death Sound
	void PlayerDeathSound(){
		GameObject audioObjetc = GameObject.Find ("PlayerDeathSound");
		if (audioObjetc != null) {
			AudioSource audio = audioObjetc.GetComponent<AudioSource>();
			if(audio!= null){
				audio.Play();
			}
		}
	}

	//6- Hit Sound
	void PlayHitSound(){
		GameObject HitaudioObjetc = GameObject.Find ("PlayerHitSound");
		if (HitaudioObjetc != null) {
			AudioSource Hitaudio = HitaudioObjetc.GetComponent<AudioSource>();
			if(Hitaudio!= null){
				Hitaudio.Play();
			}
		}
	}
}
