/*Gabriela Pereira de Assis
 * RedID 818592808
 *CS583 - 3D Game Programming
 *Assignment 5 */
using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public float spawnTime = 3f;
	private float spawnDelay = 6f;

	public GameObject[] enemies;

	private int points = 1000;
	//Call the function all the time
	void Start () {

		InvokeRepeating ("Spawn", spawnTime, spawnDelay);

	}
	
	// Update is called once per frame
	void Update () {
		// checks the points and increase the points 
		if (GameController.score >= points) {
			if(spawnDelay > 1){
				spawnDelay -= 0.5f;
			}
			points+=1000;
			CancelInvoke();
			//cals the start again with the new value
			Start();
		}



	}
	void Spawn(){
		//initialize a random enemy
		int enemyIndex = Random.Range (0, enemies.Length);
		Instantiate (enemies [enemyIndex], transform.position, transform.rotation);
	}
}
