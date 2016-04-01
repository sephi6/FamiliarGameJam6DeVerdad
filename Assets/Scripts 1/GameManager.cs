using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int piedra;
	public int tijera;
	public int papel;

	public int piedraMareo;
	public int tijeraMareo;
	public int papelMareo;

	public Text textoPiedra;
	public Text textoTijera;
	public Text textoPapel;

	public Text textoPiedraMareo;
	public Text textoTijeraMareo;
	public Text textoPapelMareo;

	private bool botonActivo;

	// Use this for initialization
	void Start () {
		iniciaJuego ();
	}
	
	// Update is called once per frame
	void Update () {
		cambiaTextos ();
	}

	private void iniciaJuego () {
		//this.piedra = piedra;
		
		//tijera = 2;

		//piedraMareo = 0;
		//tijeraMareo = 0;
		//papelMareo = 0;

		botonActivo = true;
	}

	private void cambiaTextos () {
		textoPiedra.text = piedra.ToString();
		textoTijera.text = tijera.ToString();
		textoPapel.text = papel.ToString();

		textoPiedraMareo.text = piedraMareo.ToString();
		textoTijeraMareo.text = tijeraMareo.ToString();
		textoPapelMareo.text = papelMareo.ToString();
	}

	public void juegaCarta (int carta) {
		
	}
}
