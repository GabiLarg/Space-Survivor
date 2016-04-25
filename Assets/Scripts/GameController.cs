/*Gabriela Pereira de Assis
 * RedID 818592808
 *CS583 - 3D Game Programming
 *Assignment 5 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//this classes controls the score, time and shows the HP
public class GameController : MonoBehaviour {

	public Text ScoreText;
	public static int score = 0;

	public Text HpText;

	public Text TimeCount;
	public static float timeRemaining=40f;
	public bool timeElapsed = false;


	// Use this for initialization

	void Start () {
		HpText.text = PlayerHealth.publichp+"";
		InvokeRepeating ("decreaseTimeRemaining", 1.0f, 1.0f);

	}
	
	// Update is called once per frame
	void Update () {
		HpText.text =PlayerHealth.publichp+"x";
		ScoreText.text="Score: "+score;
		TimeCount.text = "Time: "+timeRemaining;
		if (timeRemaining <= 0) {
			timeRemaining = 0;
			StopTime();
		}

	}
	public static void AddScore(){
		score += 100;
	}

	public static void SubScore(){
		score -= 50;
	}
	void decreaseTimeRemaining()
	{
		timeRemaining --;
	}

	public static void AddTime(){
		timeRemaining +=3;
	}
	public static void SubTime(){
		timeRemaining -=3;	
	}

	public void StopTime(){
		CancelInvoke();
	}

}
