/*Gabriela Pereira de Assis
 * RedID 818592808
 *CS583 - 3D Game Programming
 *Assignment 5 */
using UnityEngine;
using System.Collections;

public class BulletTrigger : MonoBehaviour {
	//carry the prefab of the bullet
	public Transform bulletPrefab;
	//wait a time between the shoots
	public float shootingRate = 0.25f;

	private float bulletCoolDown;
	// bullet at begining is 0 so I can shot 
	void Start () {
		bulletCoolDown =0f;
	}
	
	//Time to wait between shots
	void Update () {
		//decrese the time to wait for next shot
		if(bulletCoolDown >0){
			bulletCoolDown -= Time.deltaTime;
		}

	}

	public void Attack(bool isEnemy){
		if(CanAttack){
			bulletCoolDown = shootingRate;

			var bulletTransform = Instantiate(bulletPrefab) as Transform;

			bulletTransform.position = transform.position;

			BulletScript bullet = bulletTransform.gameObject.GetComponent<BulletScript>();
			if(bullet!=null){
				bullet.isEnemyShot = isEnemy;
			}

			MoveControl move = bulletTransform.gameObject.GetComponent<MoveControl>();

			if(move!=null){
				if(isEnemy){
					move.direction = new Vector2(0, -1.0f);
				}else{
					move.direction = this.transform.up;
				}
			}

		}
	}

	public bool CanAttack{
		get{
			//return a boolean if the time for wait shot is 0 
			return bulletCoolDown <= 0f;
		}
	}
}
