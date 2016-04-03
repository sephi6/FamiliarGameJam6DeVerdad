using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CalculaPosicion : MonoBehaviour {

	// Use this for initializationne
	public int size=0;
	public GameObject[] posiciones = new GameObject[12];
	public Card.TIPO[] posicionesTipadas = new Card.TIPO[12];
	public GameObject[] ciudad = new GameObject[12];

	public Recurso ruina;
	public Recurso cultivo;
	public Recurso militar;
	public Recurso construccion;
	public Recurso cultivoMareo;
	public Recurso militarMareo;
	public Recurso construccionMareo;

	public GameManager gameManager;
	public GameObject particulaDestructiva;
	public GameObject particulaConstructiva;

	void Start () {
		for (int i = 0; i < ciudad.Length; i++) {
			ciudad [i] = null;
		}

		for (int i = 0; i < posicionesTipadas.Length; i++) {
			posicionesTipadas [i] = Card.TIPO.VACIO;
		}
		/*
       for (int i = 0; i < posiciones.Length;i++ )
       {
            int random=Random.Range(0, 2);
            if (random == 0)
            {
                posicionesOcupadas[i] = true;
                construye(i, prueba[Random.Range(0,3)]);
            }
            else
            {
               posicionesOcupadas[i] = false;
            }
        }
        */

	}

	public void log () {
		Debug.Log ("OK");
	}

	// Update is called once per frame
	void Update () {

		/*
        if (Input.GetKeyDown(KeyCode.W))
        {
           int random= Random.Range(0, 12);

           if (!posicionLibre(random))
          {
               construye(random, ruina);
           }
           else
           {
               Debug.Log("Posición ocupada");
           }
        }
        */

	}

	public bool posicionLibre(int pos)
	{
		return (posicionesTipadas[pos] == Card.TIPO.NULL || posicionesTipadas[pos] == Card.TIPO.VACIO);
	}

	public void destruye (Card.TIPO tipo) {
		construye (consiguePosicionOcupada(tipo), Card.TIPO.NULL, false);
	}

	public int construye(Card.TIPO tipo, bool mareo) {
		int pos = consiguePosicionLibreRandom ();
		construye (pos, tipo, mareo);
		return pos;
	}

	public void construye(int pos, Card.TIPO tipo, bool mareo) {
		switch (tipo) {
		case Card.TIPO.PAPEL:
			construye (pos, (mareo) ? cultivoMareo : cultivo);
			break;
		case Card.TIPO.PIEDRA:
			construye (pos, (mareo) ? construccionMareo : construccion);
			break;
		case Card.TIPO.TIJERA:
			construye (pos, (mareo) ? militarMareo : militar);
			break;
		default:
			construye (pos, ruina);
			break;
		}
	}

	public int construye(Recurso recurso) {
		int pos = consiguePosicionLibreRandom ();
		construye (pos, recurso);
		return pos;
	}

	public void construye(int pos, Recurso recurso)
	{
		// INSTANCIAR SISTEMA DE PARTICULAS
		posicionesTipadas[pos] = recurso.tipo;
		if (ciudad[pos] != null) {
			Debug.Log ("SOLAR: " + ciudad[pos].ToString());
			DestroyImmediate (ciudad[pos]);
		} else {
			Debug.Log ("Nada que destruir en " + pos);
		}
		GameObject aux = Instantiate(recurso.gameObject, posiciones[pos].transform.position,Quaternion.identity) as GameObject;
		if (aux == null)
			Debug.Log ("T________________T");
		else
			ciudad [pos] = aux;
	}

	public int consiguePosicionLibreOrdenado()
	{
		int res=-1;
		for (int i=0; i < posicionesTipadas.Length; i++)
		{
			if (posicionesTipadas[i] == Card.TIPO.NULL || posicionesTipadas[i] == Card.TIPO.VACIO)
			{
				return i;
			}

		}
		return res;
	}

	public int consiguePosicionLibreRandom()
	{
		int res = -1;
		int random; 
		bool bucle=true;
        int cont = 0;
		while (bucle)
		{
            cont++;
			random = Random.Range(0, posicionesTipadas.Length);
			if (posicionesTipadas[random] == Card.TIPO.NULL || posicionesTipadas[random] == Card.TIPO.VACIO)
			{
				res=random;
				bucle = false;
			}
            if (cont > 12000)
            {
                bucle = false;
            }
		}
		return res;
	}

	public int consiguePosicionOcupada (Card.TIPO tipo) {
		int resultado = -1;int random; 
		bool bucle=true;
		while (bucle)
		{
			random = Random.Range(0, posicionesTipadas.Length);
			if (posicionesTipadas[random] == tipo)
			{
				resultado=random;
				bucle = false;
			}
		}
		return resultado;
	}
}
