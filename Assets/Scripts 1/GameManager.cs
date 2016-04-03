using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public enum estadosJuego { INICIO,ROBA,JUEGACARTA,DESTRUCCION,CONSTRUCCION,FIN_DE_TURNO,FIN,ESPERA}
	public estadosJuego estadoActual;

	public static GameManager instance; // SINGLETONe

	public Dictionary<Card.TIPO, int> recursos = new Dictionary<Card.TIPO, int> ();

	public List<GameObject> botones;
	public List<GameObject> prefabs;
	public GameObject panel;
	public CalculaPosicion calculaPosicion;
	public Animator panelVictoria;
	public Text textoVictoria;
	public Espera espera;

    public Animator textoMaquina;
    public Text textMaquina;

	public System.Random rand;

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

	private int posConstruccionIA;

	// Use this for initializa
	void Start () {
		posConstruccionIA = -1;
		recursos[Card.TIPO.PIEDRA] = 1;
		recursos[Card.TIPO.PAPEL] = 1;
		recursos[Card.TIPO.TIJERA] = 1;
		calculaPosicion = (CalculaPosicion) this.GetComponent<CalculaPosicion> ();
		calculaPosicion.log ();
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
		//rand = new System.Random (System.DateTime.Now.Millisecond);
		cambiaTextos ();
		repintaCartas ();
		switch(estadoActual){
		case(estadosJuego.ESPERA):break; // No hagas nada quillo
		case(estadosJuego.INICIO):
			Debug.Log ("Estado inicio");
			estadoActual = estadosJuego.ESPERA;
			iniciaJuego ();
			break; // Nueva partida
		case(estadosJuego.FIN_DE_TURNO):
			Debug.Log ("Estado fin de turno");
			estadoActual = estadosJuego.ESPERA;
			turno ();
			break; // Calculamos si perdemos
		case(estadosJuego.FIN):
			Debug.Log ("Estado fin de juego");
            panelVictoria.SetInteger("salida", 1);
			estadoActual = estadosJuego.ESPERA;
			if (jugarOtraPartida ())
				estadoActual = estadosJuego.ESPERA;
			else
				finDeJuego ();
			break; // La partida ya terminó
		case(estadosJuego.ROBA):
			Debug.Log ("Estado roba");
			estadoActual = estadosJuego.ESPERA;
			roba (cuantasRobo());
			enciendeBotones ();
			break;//ROBACARTA
		case(estadosJuego.JUEGACARTA): break; //JUEGACARTA
		case(estadosJuego.DESTRUCCION):
			Debug.Log ("Estado destruccion");
			estadoActual = estadosJuego.ESPERA;
			resuelveJugada (); 
			break; // DESTRUCCIÓN DE RECURSOS, CONGELACIÓN y ROBO
		case(estadosJuego.CONSTRUCCION):
			Debug.Log ("Estado construccion");
			estadoActual = estadosJuego.ESPERA;
			resuelveMareo ();
            StartCoroutine(llamaTextoJugada());
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
			if (botones.Count < 9) {
				GameObject hijo = GameObject.Instantiate (prefabs [rand.Next (0, 9)]) as GameObject;
				hijo.transform.parent = panel.transform;
				hijo.GetComponent<RectTransform> ().Rotate (new Vector3 (0, 0, 90));
				hijo.SetActive (true);
				botones.Add (hijo);
				hijo.GetComponent<pollada> ().pos = botones.Count;
			}
		}
		repintaCartas ();
	}

	private void repintaCartas () {
		int escalon = 475;
		int offset = -0;
		int contador = 0;
		foreach (GameObject boton in botones) {
			boton.GetComponent<RectTransform> ().localPosition = new Vector3 (escalon + offset, 0, 0);
			boton.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
			boton.GetComponent<pollada> ().pos = contador;
			contador++;
			offset -= 110;
		}
	}

	private void turno () {
		int total = totalRecursos ();
		if (total < 3) {
			Debug.Log ("GANASTE WEY");
			ganaste = true;
            textoVictoria.text = "The City has been destroyed.You've won.";

			estadoActual = estadosJuego.FIN;
		} else if (total > 11) {
			Debug.Log ("PERDISTE LOOSER");
            textoVictoria.text = "The City has survived. You lost.";
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
		recursos[Card.TIPO.PIEDRA] = 1 + rand.Next(0,3);
		recursos[Card.TIPO.PAPEL] = 1 + rand.Next(0,3);
		recursos[Card.TIPO.TIJERA] = 1 + rand.Next(0,3);
		roba (3);

		for (int i = 0; i < recursos [Card.TIPO.PIEDRA]; i++) {
			calculaPosicion.construye (Card.TIPO.PIEDRA, false);
		}

		for (int i = 0; i < recursos [Card.TIPO.PAPEL]; i++) {
			calculaPosicion.construye (Card.TIPO.PAPEL, false);
		}

		for (int i = 0; i < recursos [Card.TIPO.TIJERA]; i++) {
			calculaPosicion.construye (Card.TIPO.TIJERA, false);
		}

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
	public void seleccionaCartaJugador (Card.TIPO tipo, Card.ESPECIALIDAD especialidad, int idCarta) {
		apagaBotones ();
		// Buscamos la carta y la borramos

		cartaJugador = new Card (tipo, especialidad);
		cartaIA = IAEligeCarta ();
         

        
		congelado = Card.TIPO.NULL;
		Debug.Log ("El jugador elige: " + cartaJugador.tipoCarta + " " + cartaJugador.especialidadCarta );
		Debug.Log ("La IA elige: " + cartaIA.tipoCarta + " " + cartaIA.especialidadCarta );
		juegaCarta ();
	}

	public void borraBoton (int pos) {
		botones.RemoveAt (pos);
	}

    IEnumerator llamaTextoJugada()
    {
        
        textoMaquina.SetInteger("salida", 1);
        yield return new WaitForSeconds(0.5f);
        textoMaquina.SetInteger("salida", 0);
    }

	public Card IAEligeCarta () {
		int tipo;
		Card resultado;
		do { 
			tipo = rand.Next (1, 4);
			// tipo=Random.Range(1,4);
		} while (isTipoBloqueado(tipo));
		switch (tipo) {
		case 1:
			resultado = new Card (Card.TIPO.PIEDRA, Card.ESPECIALIDAD.MAQUINA);
            textMaquina.text=("The city has chosen Construction");
			break;
		case 2:
			resultado = new Card (Card.TIPO.PAPEL, Card.ESPECIALIDAD.MAQUINA);
            textMaquina.text = ("The city has chosen Farm");
			break;
		default:
			resultado = new Card (Card.TIPO.TIJERA, Card.ESPECIALIDAD.MAQUINA);
            textMaquina.text = ("The city has chosen Quarters");
			break;
		}
		return resultado;
	}

	public bool isTipoBloqueado (int tipo) {
		bool resultado = false;
		switch (tipo) {
		case 1:
			resultado = (congelado == Card.TIPO.PIEDRA) ? true : false;
			if (recursos [Card.TIPO.PIEDRA] > 5)
				resultado = false;
			break;
		case 2:
			resultado = (congelado == Card.TIPO.PAPEL) ? true : false;
			if (recursos [Card.TIPO.PAPEL] > 5)
				resultado = false;
			break;
		case 3:
			resultado = (congelado == Card.TIPO.TIJERA) ? true : false;
			if (recursos [Card.TIPO.TIJERA] > 5)
				resultado = false;
			break;
		}
		return resultado;
	}

	public void juegaCarta()
	{
		// Mostrar cartas jugdas6y6
		// Esperar hasta que las animciones terminen
		// Borrar carta de la escena y la lista
		posConstruccionIA = calculaPosicion.construye(cartaIA.tipoCarta, true);
		espera.paradaMareo();
	}


	public void construye (Card.TIPO tipo) {
		// RESGUARDO
		// Animación de construcción
		if (tipo != Card.TIPO.NULL) {
			recursos [tipo] += 1;
		}
		calculaPosicion.construye(posConstruccionIA, cartaIA.tipoCarta, false);
		Debug.Log ("IA construye un " + tipo);
	}

	public void resuelveMareo()
	{
		switch (ganador ()) {
		case -1:
			Debug.Log ("Te han contrarestado");
            textMaquina.text += "\n You've been counteract";
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
                textMaquina.text += "\n Draw";
				// animación de counter?
				playerContrarestado = true;
				IAContrarestada = true;
				construye (Card.TIPO.NULL);
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
                textMaquina.text += "\n The City has been counteract";
				// animación de counter?
				playerContrarestado = false;
				IAContrarestada = true;
				construye (Card.TIPO.NULL);
			}
			break;
		}
		espera.paradaConstruccion ();
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
				bool sigue = true;
				for (int i = 0; i < 3 && sigue; i++) {
					sigue = destruye (cartaJugador.tipoCarta);
				}
				recursos [cartaJugador.tipoCarta] = (recursos [cartaJugador.tipoCarta] < 0) ? 0: recursos [cartaJugador.tipoCarta];
				break;
			case Card.ESPECIALIDAD.PRISA:
				congelado = cartaJugador.tipoCarta;
				roba (1);
				// ANIMACION DE CONGELACION
				break;
			case Card.ESPECIALIDAD.NORMAL:
				destruye(cartaJugador.tipoCarta);
				recursos [cartaJugador.tipoCarta] = (recursos [cartaJugador.tipoCarta] < 0) ? 0: recursos [cartaJugador.tipoCarta];
				break;
			default:
				Debug.Log ("EL JUGADOR HA ESCOGIDO UNA CARTA DE LA MAQUINA, MILAGRO!!");
				break;
			}
		}
		estadoActual = estadosJuego.FIN_DE_TURNO;
	}

	public bool destruye (Card.TIPO tipo) {
		bool resultado = false;
		if (recursos [tipo] > 0) {
			resultado = true;
			calculaPosicion.destruye (tipo);
			recursos [tipo] -= 1;
		}
		return resultado;
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
