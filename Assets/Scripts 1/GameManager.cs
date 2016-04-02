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

	public void juegaCarta (Card cartaIA, Card cartaJugador) {
        switch (ganaJugador(cartaIA, cartaJugador)) {
            case -1:
                // jugador pierde
                break;
            case 0:
                // empate
                break;
            case 1:
                // jugador gana
                break;
        }
	}

    public int ganaJugador(Card cartaIA, Card cartaJugador)
    {
        int resultado;
        if ((cartaJugador.tipoCarta == Card.TIPO.PAPEL && cartaIA.tipoCarta == Card.TIPO.TIJERA) || (cartaJugador.tipoCarta == Card.TIPO.PIEDRA && cartaIA.tipoCarta == Card.TIPO.PAPEL) ||(cartaJugador.tipoCarta == Card.TIPO.TIJERA && cartaIA.tipoCarta == Card.TIPO.PIEDRA)) {
            resultado = -1;
        } else if ((cartaJugador.tipoCarta == Card.TIPO.PAPEL && cartaIA.tipoCarta == Card.TIPO.PAPEL) || (cartaJugador.tipoCarta == Card.TIPO.PIEDRA && cartaIA.tipoCarta == Card.TIPO.PIEDRA) ||(cartaJugador.tipoCarta == Card.TIPO.TIJERA && cartaIA.tipoCarta == Card.TIPO.TIJERA)) {
            resultado = 0;
        } else {
            resultado = 1;
        }
        return resultado;
    }
}
