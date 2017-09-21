using UnityEngine;
using System.Collections;

public class CollectGem : MonoBehaviour {

	public AudioClip soundEffect;

    void OnTriggerEnter2D(Collider2D target){
    	PersistentManager.dataStore.gemsCollected += 1;

    	if(target.gameObject.tag == "Player"){

    		if(soundEffect){
    			AudioSource.PlayClipAtPoint(soundEffect, transform.position);
    		}
    		Destroy(gameObject);
    	}
    }
}
