using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UIManager : MonoBehaviour {

    public GameManager gameManager;

    public Animator botonPanel;

    

	// Use this for initialization
	void Start () {
	    
	}

    public void cierraPestaña()
    {
        if (botonPanel.GetInteger("salida") == 1)
        {
			botonPanel.SetInteger("salida", 0);
        }
        else
        {
			botonPanel.SetInteger("salida", 1);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
	}

	public void fuente (BaseEventData data) {
		Debug.Log ("Caller: " + data.selectedObject.name);
	}

    public void cartaSeleccionada(int idButton)
    {
		Debug.Log ("UIManager, seleccionando el boton con id " + idButton);
        switch (idButton)
        {
            case 1:
            //PIEDRA NORMAL
            gameManager.seleccionaCartaJugador(Card.TIPO.PIEDRA,Card.ESPECIALIDAD.NORMAL,idButton);
                break;
            case 2:
            //PIEDRA PRISA
			gameManager.seleccionaCartaJugador(Card.TIPO.PIEDRA, Card.ESPECIALIDAD.PRISA,idButton);
                break;
            case 3:
            //PIEDRA LENTA
			gameManager.seleccionaCartaJugador(Card.TIPO.PIEDRA, Card.ESPECIALIDAD.LENTA,idButton);
                break;
            case 4:
            //PIEDRA NORMAL
			gameManager.seleccionaCartaJugador(Card.TIPO.PAPEL, Card.ESPECIALIDAD.NORMAL,idButton);
                break;
            case 5:
            //PIEDRA PRISA
			gameManager.seleccionaCartaJugador(Card.TIPO.PAPEL, Card.ESPECIALIDAD.PRISA,idButton);
                break;
            case 6:
            //PIEDRA LENTA
			gameManager.seleccionaCartaJugador(Card.TIPO.PAPEL, Card.ESPECIALIDAD.LENTA,idButton);
                break;
            case 7:
            //PIEDRA NORMAL
			gameManager.seleccionaCartaJugador(Card.TIPO.TIJERA,Card.ESPECIALIDAD.NORMAL,idButton);
                break;
            case 8:
            //PIEDRA PRISA
			gameManager.seleccionaCartaJugador(Card.TIPO.TIJERA, Card.ESPECIALIDAD.PRISA,idButton);
                break;
            case 9:
            //PIEDRA LENTA
			gameManager.seleccionaCartaJugador(Card.TIPO.TIJERA, Card.ESPECIALIDAD.LENTA,idButton);
                break;
        }
    }
}
