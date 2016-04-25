/*Gabriela Pereira de Assis
 * RedID 818592808
 *CS583 - 3D Game Programming
 *Assignment 5 */
using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	//1- Damage value 
	public int damage = 1;
	//2- Define if it is a Enemy shot or not
	public bool isEnemyShot;

	void Start () {
		//3 - Destroy the "bullet" after 20 seconds 
		Destroy (gameObject, 20);
	}
	

}
