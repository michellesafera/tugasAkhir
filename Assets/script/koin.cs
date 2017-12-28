using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koin : MonoBehaviour {

	//menyambungkan gerak dengan obstacle
	gerak KomponenGerak;

	// Use this for initialization
	void Start () {
		//menyambungkan player di script gerak dengan script obstacle
		KomponenGerak = GameObject.Find ("player").GetComponent<gerak> (); 
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.transform.tag == "Player") {
			KomponenGerak.koin++;
			gerak.score++;
			Destroy (gameObject);
		}

	}

}
