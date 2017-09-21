using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour {
	public string levelPrefix = "Level0";

	public void loadLevel(int levelID) {
		SceneManager.LoadScene( levelPrefix + levelID);
	}
	
}
