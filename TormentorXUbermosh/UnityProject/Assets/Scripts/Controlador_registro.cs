using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_registro : MonoBehaviour{
	public GameObject menuMuerte , registro ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void Registrarse(){
		menuMuerte.SetActive(false);
		registro.SetActive(true);
		
	}
	
	public void Volver(){
		registro.SetActive(false);
		menuMuerte.SetActive(true);
		
		
	}
}