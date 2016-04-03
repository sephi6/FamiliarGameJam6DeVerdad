using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManagerMenu : MonoBehaviour {

    public Button abrirHow;
    public Button cerrarHow;

    public Animator panelHow;

    public Button playAgain;
    public Button mainMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void abreHow()
    {
        panelHow.SetInteger("cierra", 1);
        
    }

    public void cierraHow()
    {
        panelHow.SetInteger("cierra", 0);
    }

    public void cargaJuego()
    {
        Application.LoadLevel(1);
    }
}
