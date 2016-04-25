using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MuteScript : MonoBehaviour {

	//This Script Plays or mute the song and changes the button image
	public Sprite mute;
	public Sprite noMute;
	public Button button;
	private bool isMute= false;

	public GameObject audioObjetc;

	public void Mute(){
			AudioSource audio = audioObjetc.GetComponent<AudioSource> ();
			if (audio != null) {	
				if (!isMute) {
					button.image.overrideSprite = mute;
					audio.mute = true;
					isMute = true;
				} else {
					button.image.overrideSprite = noMute;
					audio.mute = false;
					isMute = false;			
				}
			}
			
	}
}
