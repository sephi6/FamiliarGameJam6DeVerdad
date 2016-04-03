using UnityEngine;
using System.Collections;

public class Card {

    public enum TIPO
    {
        PIEDRA,
        PAPEL,
        TIJERA,
		NULL,
		VACIO
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
