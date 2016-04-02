using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

    public enum TIPO
    {
        PIEDRA,
        PAPEL,
        TIJERA
    }

    public enum ESPECIALIDAD
    {
        NORMAL,
        PRISA,
        LENTA,
        MAQUINA
    }

    public TIPO tipoCarta;
    public ESPECIALIDAD especialidadCarta;
    public Vector2 sumadores;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Card(TIPO tipoCarta, ESPECIALIDAD especialidadCarta)
    {
        this.tipoCarta = tipoCarta;
        this.especialidadCarta = especialidadCarta;
    }

    //public void creaCarta(TIPO tipoCarta,  ESPECIALIDAD especialidad)
    //{
    //    switch(especialidad){
    //        case ESPECIALIDAD.LENTA:
    //            sumadores=new Vector2(-1,-1);

    //    }



    //}

}
