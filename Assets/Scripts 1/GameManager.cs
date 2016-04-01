using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int piedra;
	public int tijera;
	public int papel;

	public int piedraMareo;
	public int tijeraMareo;
	public int papelMareo;

	private bool botonActivo;

	// Use this for initialization
	void Start () {
		iniciaJuego ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void iniciaJuego () {
		piedra = 2;
		papel = 2;
		tijera = 2;

		piedraMareo = 0;
		tijeraMareo = 0;
		papelMareo = 0;

		botonActivo = true;
	}

	public void juegaCarta (int carta) {
		
	}
}
