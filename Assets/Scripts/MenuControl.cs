using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

	public void PlayButton(string newLevel){
		SceneManager.LoadScene(newLevel);
	}
	
	public void QuitButton(){
		Application.Quit();
	}
}
