/*Gabriela Pereira de Assis
 * RedID 818592808
 *CS583 - 3D Game Programming
 *Assignment 5 */
using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {


	public static int finalScore;

	public Vector2 speed = new Vector2(10, 10);
	private Vector2 movement;

	private SpriteRenderer sprite;

	public Sprite spaceshipIdle;
	public Sprite spaceshipMove;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		//1 - Movement control
		float inputY = 0; 
		float inputX= 0;
		sprite.sprite = spaceshipIdle;
		//up 1+ to axis Y
		if (Input.GetKey (KeyCode.W)) {
			inputY = 1;
			//changes the Sprite
			sprite.sprite = spaceshipMove;
		
		}
		//down 1- to axis Y
		else if (Input.GetKey (KeyCode.S)) {
			inputY = -1;
			sprite.sprite = spaceshipMove;

		}
		//right 1+ to axis X
		else if (Input.GetKey (KeyCode.D)) {
			inputX = 1;
			sprite.sprite = spaceshipMove;
						
		}
		//left 1-to axis X
		else if (Input.GetKey (KeyCode.A)) {
			inputX = -1;
			sprite.sprite = spaceshipMove;

		} else {
			//if nothing or something else than WASD is pressed change to idle image 
			sprite.sprite = spaceshipIdle;
						
		}

		movement = new Vector2 (speed.x * inputX, speed.y * inputY);

		//2 - Shooting
		//check if left button of mouse were pressed
		bool shoot = Input.GetButtonDown ("Fire1");

		if (shoot) {
			//once is shooted plays song
			ShootSound();
			BulletTrigger trigger = GetComponent<BulletTrigger>();
			if(trigger!=null){
				//seed to attack function that its not the enemy
				trigger.Attack(false);
			}
		}


	}	

	//3 - Apply the movement
	void FixedUpdate(){
		//move the spaceship by add force
		rigidbody2D.velocity = movement;
	}
	//4 - In cse of distruction saves the score and calls the Game  Over scene
	void OnDestroy(){
		//get the score to be displayed
		finalScore = GameController.score;
		//run Gameover Screne
		Application.LoadLevel ("GameOver");
		GameController.score = 0;
		GameController.timeRemaining = 40f;
	}
	//5 - Shoot sound
	void ShootSound(){
		GameObject audioObjetc = GameObject.Find ("ShootSound");
		if (audioObjetc != null) {
			AudioSource audio = audioObjetc.GetComponent<AudioSource>();
			if(audio!= null){
				audio.Play();
			}
		}
	}
}
