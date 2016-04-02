using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    public GameManager gameManager;

    public Animator botonPanel;

    

	// Use this for initialization
	void Start () {
	    
	}

    public void cierraPestaña()
    {
        if (botonPanel.GetInteger("cierra") == 1)
        {
            botonPanel.SetInteger("cierra", 0);
        }
        else
        {
            botonPanel.SetInteger("cierra", 1);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void cartaSeleccionada(int idButton)
    {
        switch (idButton)
        {
            case 1:
                //PIEDRA NORMAL
                gameManager.seleccionaCartaJugador(Card.TIPO.PIEDRA,Card.ESPECIALIDAD.NORMAL);
                break;
            case 2:
                //PIEDRA PRISA
                gameManager.seleccionaCartaJugador(Card.TIPO.PIEDRA, Card.ESPECIALIDAD.PRISA);
                break;
            case 3:
                //PIEDRA LENTA
                gameManager.seleccionaCartaJugador(Card.TIPO.PIEDRA, Card.ESPECIALIDAD.LENTA);
                break;
            case 4:
                //PIEDRA NORMAL
                gameManager.seleccionaCartaJugador(Card.TIPO.PAPEL, Card.ESPECIALIDAD.NORMAL);
                break;
            case 5:
                //PIEDRA PRISA
                gameManager.seleccionaCartaJugador(Card.TIPO.PAPEL, Card.ESPECIALIDAD.PRISA);
                break;
            case 6:
                //PIEDRA LENTA
                gameManager.seleccionaCartaJugador(Card.TIPO.PAPEL, Card.ESPECIALIDAD.LENTA);
                break;
            case 7:
                //PIEDRA NORMAL
                gameManager.seleccionaCartaJugador(Card.TIPO.TIJERA,Card.ESPECIALIDAD.NORMAL);
                break;
            case 8:
                //PIEDRA PRISA
                gameManager.seleccionaCartaJugador(Card.TIPO.TIJERA, Card.ESPECIALIDAD.PRISA);
                break;
            case 9:
                //PIEDRA LENTA
                gameManager.seleccionaCartaJugador(Card.TIPO.TIJERA, Card.ESPECIALIDAD.LENTA);
                break;
        }
    }
}
