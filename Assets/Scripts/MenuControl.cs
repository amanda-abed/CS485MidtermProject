using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

	public Transform mainMenu, optionsMenu;

	public void PlayButton(string newLevel){
		SceneManager.LoadScene(newLevel);
	}
	
	public void QuitButton(){
		Application.Quit();
	}

	public void HowToPlayButton(bool clicked){
		if(clicked == true){
				optionsMenu.gameObject.SetActive(clicked);
				mainMenu.gameObject.SetActive(false);
			}else{
				optionsMenu.gameObject.SetActive(clicked);
				mainMenu.gameObject.SetActive(true);
			}
	}
}
