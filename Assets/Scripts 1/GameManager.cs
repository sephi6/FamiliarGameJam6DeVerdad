using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	// VALORES INICIALES DE RECURSOS DE LA IA
	public int piedra;
	public int tijera;
	public int papel;

    public enum estadosJuego { INICIO,ROBA,JUEGACARTA,DESTRUCCION,CONSTRUCCION,FIN_DE_TURNO,FIN,ESPERA}

    public estadosJuego estadoActual;

    public static GameManager instance; // SINGLETON

	public Dictionary<Card.TIPO, int> recursos = new Dictionary<Card.TIPO, int> ();

	public List<GameObject> botones;
	public List<GameObject> prefabs;

	public System.Random rand;

	public int piedraMareo;
	public int tijeraMareo;
	public int papelMareo;

	public Text textoPiedra;
	public Text textoTijera;
	public Text textoPapel;

	private Card cartaIA;
	private Card cartaJugador;

	private bool ganaste;
	private bool botonActivo;
	private bool playerContrarestado;
	private bool IAContrarestada;

	private Card.TIPO congelado;

	// Use this for initialization
	void Start () {
        recursos[Card.TIPO.PIEDRA] = piedra;
        recursos[Card.TIPO.PAPEL] = papel;
        recursos[Card.TIPO.TIJERA] = tijera;
		rand = new System.Random (System.DateTime.Now.Millisecond);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Se ha detectado más de una instancia");
		}
		botonActivo = false;
		estadoActual = estadosJuego.INICIO;
	}
	
	// Update is called once per frame
	void Update () {
		rand = new System.Random (System.DateTime.Now.Millisecond);
		cambiaTextos ();
		switch(estadoActual){
		case(estadosJuego.ESPERA):break; // No hagas nada quillo
		case(estadosJuego.INICIO):
			estadoActual = estadosJuego.ESPERA;
			iniciaJuego ();
			break; // Nueva partida
		case(estadosJuego.FIN_DE_TURNO):
			estadoActual = estadosJuego.ESPERA;
			turno ();
			break; // Calculamos si perdemos
		case(estadosJuego.FIN):
			estadoActual = estadosJuego.ESPERA;
			if (jugarOtraPartida ())
				estadoActual = estadosJuego.ESPERA;
			else
				finDeJuego ();
			break; // La partida ya terminó
		case(estadosJuego.ROBA):
			estadoActual = estadosJuego.ESPERA;
			roba (cuantasRobo());
			enciendeBotones ();
			break;//ROBACARTA
	    case(estadosJuego.JUEGACARTA): break; //JUEGACARTA
		case(estadosJuego.DESTRUCCION):
			estadoActual = estadosJuego.ESPERA;
			resuelveJugada (); 
			break; // DESTRUCCIÓN DE RECURSOS, CONGELACIÓN y ROBO
		case(estadosJuego.CONSTRUCCION):
			estadoActual = estadosJuego.ESPERA;
			resuelveMareo ();
			break; // CONSTRUCCION Y COUNTER
        }
	}

	private int cuantasRobo () {
		int resultado = 1;
		if (recursos [Card.TIPO.PIEDRA] == 0)
			resultado++;
		if (recursos [Card.TIPO.PAPEL] == 0)
			resultado++;
		if (recursos [Card.TIPO.TIJERA] == 0)
			resultado++;
		if (recursos [Card.TIPO.PIEDRA] > 4)
			resultado--;
		if (recursos [Card.TIPO.PAPEL] > 4)
			resultado--;
		if (recursos [Card.TIPO.TIJERA] > 4)
			resultado--;

		return (resultado > -1) ? resultado : 0;
	}

	private void roba (int n) {
		// añade n botones a la lista y a la escena
		for (int i = 0; i < n; i++) {
			botones.Add ((GameObject) GameObject.Instantiate(prefabs[rand.Next(0,9)]));
		}
		repintaCartas ();
	}

	private void repintaCartas () {
		int escalon = -60;
		int offset = -0;
		foreach (GameObject boton in botones) {
			boton.GetComponent<RectTransform> ().position = new Vector3 (escalon + offset, 0, 0);
			offset -= 110;
		}
	}

	private void turno () {
		int total = totalRecursos ();
		if (total < 3) {
			Debug.Log ("GANASTE WEY");
			ganaste = true;
			estadoActual = estadosJuego.FIN;
		} else if (total > 11) {
			Debug.Log ("PERDISTE LOOSER");
			ganaste = false;
			estadoActual = estadosJuego.FIN;
		} else {
			estadoActual = estadosJuego.ROBA;
		}
	}

	private bool jugarOtraPartida () {
		bool resultado = false;
		// TODO: logica de querer repetir o no la partida
		return resultado;
	}

	private void finDeJuego () {
		Application.Quit ();
	}

	private void iniciaJuego () {
		congelado = Card.TIPO.NULL;
		// robas tres cartas
		estadoActual = estadosJuego.ROBA;
	}

	private int totalRecursos () {
		return recursos [Card.TIPO.PIEDRA] + recursos [Card.TIPO.PAPEL] + recursos [Card.TIPO.TIJERA];
	}

	private void cambiaTextos () {
		textoPiedra.text = recursos[Card.TIPO.PIEDRA].ToString();
		textoTijera.text = recursos[Card.TIPO.TIJERA].ToString();
		textoPapel.text = recursos[Card.TIPO.PAPEL].ToString();
	}

	/// <summary>
	///  selecciona carta jugador, est funcion será llamada al pulsar un boton (una carta)
	/// </summary>
	/// <param name="cartaIA">Carta I.</param>
	/// <param name="cartaJugador">Carta jugador.</param>
	public void seleccionaCartaJugador (Card.TIPO tipo, Card.ESPECIALIDAD especialidad) {
		apagaBotones ();
		// TODO: Comprobar que podemos crear la carta (por si no tenemos caras de ese tipo)
		cartaJugador = new Card (tipo, especialidad);
		// Desactivamos todos los botones
		cartaIA = IAEligeCarta ();
		congelado = Card.TIPO.NULL;
		Debug.Log ("El jugador elige: " + cartaJugador.tipoCarta + " " + cartaJugador.especialidadCarta );
		Debug.Log ("La IA elige: " + cartaIA.tipoCarta + " " + cartaIA.especialidadCarta );
		juegaCarta ();
	}

	public Card IAEligeCarta () {
		int tipo;
		Card resultado;
		do { 
			tipo = rand.Next (1, 4);
		} while (isTipoBloqueado(tipo));
		switch (tipo) {
		case 1:
			resultado = new Card (Card.TIPO.PIEDRA, Card.ESPECIALIDAD.MAQUINA);
			break;
		case 2:
			resultado = new Card (Card.TIPO.PAPEL, Card.ESPECIALIDAD.MAQUINA);
			break;
		default:
			resultado = new Card (Card.TIPO.TIJERA, Card.ESPECIALIDAD.MAQUINA);
			break;
		}
		return resultado;
	}

	public bool isTipoBloqueado (int tipo) {
		// Conductor, esto servirá para determinar cuando la IA no puede jugar un tipo de carta
		bool resultado = false;
		switch (tipo) {
		case 1:
			resultado = (congelado == Card.TIPO.PIEDRA) ? false : true;
			if (recursos [Card.TIPO.PIEDRA] > 4)
				resultado = false;
			break;
		case 2:
			resultado = (congelado == Card.TIPO.PAPEL) ? false : true;
			if (recursos [Card.TIPO.PAPEL] > 4)
				resultado = false;
			break;
		case 3:
			resultado = (congelado == Card.TIPO.TIJERA) ? false : true;
			if (recursos [Card.TIPO.TIJERA] > 4)
				resultado = false;
			break;
		}
		return resultado;
	}

    public void juegaCarta()
    {
		// Mostrar cartas jugdas
		// Esperar hasta que las animciones terminen
		// Borrar carta de la escena y la lista

		estadoActual = estadosJuego.CONSTRUCCION;
    }


	public void construye (Card.TIPO tipo) {
		// RESGUARDO
		// Animación de construcción
		recursos[tipo] += 1;
		Debug.Log ("IA construye un " + tipo);
	}

    public void resuelveMareo()
    {
		switch (ganador ()) {
		case -1:
			Debug.Log ("Te han contrarestado");
			// animación de counter?
			playerContrarestado = true;
			IAContrarestada = false;
			construye (cartaIA.tipoCarta);
			break;

		case 0:
			if (cartaJugador.especialidadCarta == Card.ESPECIALIDAD.LENTA) {
				Debug.Log ("Lentas no contrrestan");
				playerContrarestado = false;
				IAContrarestada = false;
				construye (cartaIA.tipoCarta);
			} else {
				Debug.Log ("Double counter");
				// animación de counter?
				playerContrarestado = true;
				IAContrarestada = true;
			}
			break;

		case 1:
			if (cartaJugador.especialidadCarta == Card.ESPECIALIDAD.LENTA) {
				Debug.Log ("Lentas no contrrestan");
				playerContrarestado = false;
				IAContrarestada = false;
				construye (cartaIA.tipoCarta);
			} else {
				Debug.Log ("Contrarestas a la IA");
				// animación de counter?
				playerContrarestado = false;
				IAContrarestada = true;
			}
			break;
		}
        estadoActual = estadosJuego.DESTRUCCION;
	}

	public void apagaBotones () {
		foreach (GameObject boton in botones) {
			boton.GetComponent<Button> ().interactable = false;
		}
	}

	public void enciendeBotones () {
		foreach (GameObject boton in botones) {
			boton.GetComponent<Button> ().interactable = true;
		}
	}

	/// <summary>
	/// Termin la jugada en función de si has sido contrrestado o no
	/// </summary>
	/// <param name="cartaIA">Carta I.</param>
	/// <param name="cartaJugador">Carta jugador.</param>
    public void resuelveJugada()
    {
		if (!playerContrarestado) {
			switch (cartaJugador.especialidadCarta) {
			case Card.ESPECIALIDAD.LENTA:
				recursos [cartaJugador.tipoCarta] -= 3;
				recursos [cartaJugador.tipoCarta] = (recursos [cartaJugador.tipoCarta] < 0) ? 0: recursos [cartaJugador.tipoCarta];
				Debug.Log ("PIM, destruyes 3 " + cartaJugador.tipoCarta);
				break;
			case Card.ESPECIALIDAD.PRISA:
				congelado = cartaJugador.tipoCarta;
				// Roba una carta
				Debug.Log ("Congelas " + cartaJugador.tipoCarta);
				break;
			case Card.ESPECIALIDAD.NORMAL:
				recursos [cartaJugador.tipoCarta] -= 1;
				recursos [cartaJugador.tipoCarta] = (recursos [cartaJugador.tipoCarta] < 0) ? 0: recursos [cartaJugador.tipoCarta];
				Debug.Log ("Destruyes 1 " + cartaJugador.tipoCarta);
				break;
			default:
				Debug.Log ("EL JUGADOR HA ESCOGIDO UNA CARTA DE LA MAQUINA, MILAGRO!!");
				break;
			}
		}
        estadoActual = estadosJuego.FIN_DE_TURNO;
    }

    public int ganador()
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

    public Card.TIPO devuelveTipoGanador(Card.TIPO tipo)
    {
        Card.TIPO res;
        if (tipo == Card.TIPO.PIEDRA)
        {
            res = Card.TIPO.PAPEL;
        }
        else if (tipo == Card.TIPO.PAPEL)
        {
            res = Card.TIPO.TIJERA;
        }
        else
        {
            res = Card.TIPO.PIEDRA;
        }
        return res;
    }

    public Card.TIPO devuelveTipoPerdedor(Card.TIPO tipo)
    {
        Card.TIPO res;
        if (tipo == Card.TIPO.PIEDRA)
        {
            res = Card.TIPO.TIJERA;
        }
        else if (tipo == Card.TIPO.PAPEL)
        {
            res = Card.TIPO.PIEDRA;
        }
        else
        {
            res = Card.TIPO.PAPEL;
        }
        return res;
    }
}
