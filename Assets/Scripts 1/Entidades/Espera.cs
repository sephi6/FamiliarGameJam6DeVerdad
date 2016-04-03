using UnityEngine;
using System.Collections;

public class Espera : MonoBehaviour {
	public GameManager gameManager;

	void Start() {
		
	}

	public void parada() {
		StartCoroutine(Example());
	}

	IEnumerator Example() {
		Debug.Log(Time.time);
		yield return new WaitForSeconds(1);
		Debug.Log(Time.time);
		gameManager.estadoActual = GameManager.estadosJuego.CONSTRUCCION;
	}

}