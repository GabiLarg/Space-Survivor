/*Gabriela Pereira de Assis
 * RedID 818592808
 *CS583 - 3D Game Programming
 *Assignment 5 */
using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	//initiates the buttons and inital music

	//1- Loads the game
	public void StartGame(){

		Application.LoadLevel ("Game");

	}
	//2- Loads the Instructions Scene
	public void InstructionsDisplay(){
		
		Application.LoadLevel ("Instructions");
		
	}
	//3- Load credits Scene
	public void CreditsButton(){
		
		Application.LoadLevel("Credits");
		
	}
	//4- Loads the menu scene
	public void MenuButton(){

		Application.LoadLevel("menu");
	
	}
	//5- quit from the game
	public void QuitButton(){
		
		Application.Quit();
		
	}

}
