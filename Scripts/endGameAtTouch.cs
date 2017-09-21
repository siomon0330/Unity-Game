using UnityEngine;
using System.Collections;

public class endGameAtTouch : MonoBehaviour {

	public bool endWithWin;


	void OnTriggerExit2D(Collider2D target){

		if (target.gameObject.tag == "Player"){

			if(endWithWin == true){
				PersistentManager.dataStore.endGameWithWin();
			}else{
				PersistentManager.dataStore.endGameWithLoss();
			}
		} 
	}




}
