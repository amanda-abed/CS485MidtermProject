using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour {

	public void PlayAgainButton(string newLevel){
		SceneManager.LoadScene(newLevel);
	}
	
	public void GoToMainMenu(string newLevel){
		SceneManager.LoadScene(newLevel);
	}
}
