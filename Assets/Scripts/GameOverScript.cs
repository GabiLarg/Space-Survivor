/*Gabriela Pereira de Assis
 * RedID 818592808
 *CS583 - 3D Game Programming
 *Assignment 5 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {
	public Text Score;
	//Game over buttons

	//Shows the final score
	void Start () {
		Score.text = PlayerControl.finalScore+"";
	}
	
	public void RetryButton(){
		Application.LoadLevel("Game");
	}
	public void MenuButton(){
		Application.LoadLevel("menu");
	}
	public void CreditsButton(){
		Application.LoadLevel("Credits");
	}
	public void QuitButton(){
		Application.Quit();
	}

}
