using UnityEngine;
using System.Collections;

public class pollada : MonoBehaviour {
	public int pos;
	public GameManager gameManager;
	// Use this for initialization
	void Start () {
	
	}

	public void grita () {
		gameManager.borraBoton (pos);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
