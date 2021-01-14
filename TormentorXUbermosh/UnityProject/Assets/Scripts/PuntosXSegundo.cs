using UnityEngine;
using UnityEngine.UI;

public class PuntosXSegundo : MonoBehaviour
{

    #region Variables
    public ControladorMenu ControladorMenu;

    public Text texto;
    
    private float contador = 0, i = 0;
    #endregion

    // Update is called once per frame
    void Update()
    {
        //Si el menu esta activo, no se pausa el contador
        if(!ControladorMenu.pausado)
            i += Time.deltaTime;

        //Si supera un segundo, la puntuacion tiene un punto extra
        if(i > 1)
        {
            contador = int.Parse(texto.text);

            contador += 1;
            texto.text = contador.ToString();
            i = 0;
        }
    }
}
