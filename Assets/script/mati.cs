using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mati : MonoBehaviour {
	gerak KomponenGerak;

	// Use this for initialization
	void Start () {
		//menyambungkan player di script gerak dengan script obstacle
		KomponenGerak = GameObject.Find ("player").GetComponent<gerak> (); 
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.transform.tag == "Player") {
			KomponenGerak.nyawa--;
			KomponenGerak.ulang = true;
		}

	}
}
