using UnityEngine;
using System.Collections;

public class Espera : MonoBehaviour {
	public GameManager gameManager;

	void Start() {
		
	}

	public void paradaMareo() {
		StartCoroutine(construccionMareo());
	}

	public void paradaConstruccion() {
		StartCoroutine(construccion());
	}

	public void paradaDestruccion() {
		StartCoroutine(destruccion());
	}

	IEnumerator construccionMareo() {
		yield return new WaitForSeconds(1);
		gameManager.estadoActual = GameManager.estadosJuego.CONSTRUCCION;
	}

	IEnumerator construccion() {
		yield return new WaitForSeconds(4);
		gameManager.estadoActual = GameManager.estadosJuego.DESTRUCCION;
	}

	IEnumerator destruccion() {
		yield return new WaitForSeconds(1);
		gameManager.estadoActual = GameManager.estadosJuego.FIN_DE_TURNO;
	}

}