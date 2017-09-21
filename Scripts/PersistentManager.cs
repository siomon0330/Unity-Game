using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;


public class PersistentManager : MonoBehaviour {

	public static PersistentManager dataStore;

	//Instance variables
	public int currentLevelID;

	//persistent variables
	public int gemsCollected;
	public int highestLevelCompleted;

	void Awake(){
		if (dataStore == null){
			DontDestroyOnLoad(gameObject);
			dataStore = this;
			Load();
		}else if (dataStore != this){
			Destroy(gameObject);
		}
	}

	public void endGameWithWin(){
		if(currentLevelID > highestLevelCompleted){
			highestLevelCompleted = currentLevelID;
		}
		Save();
		Debug.Log("Game Over - win");
		Debug.Log(SceneManager.GetActiveScene().name);
		SceneManager.LoadScene("MainMenu");
	}
	public void endGameWithLoss(){
		
		Debug.Log("Game Over - loss");
		Debug.Log(SceneManager.GetActiveScene().name);
		SceneManager.LoadScene("MainMenu");
	}



	//Saving and loading
	public void Save(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/GameData.dat");
		GameData data = new GameData();
		data.gemsCollectedTotal = gemsCollected;
		data.highestLevel = highestLevelCompleted;

		bf.Serialize(file, data);
		file.Close();
	}

	public void Load() {

		if(File.Exists(Application.persistentDataPath + "/GameData.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
			GameData data = (GameData)bf.Deserialize(file);
			file.Close();

			gemsCollected = data.gemsCollectedTotal;
			highestLevelCompleted = data.highestLevel;

		}
	}

}

[Serializable]
class GameData{
	public int gemsCollectedTotal;
	public int highestLevel;
}