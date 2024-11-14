using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarPanel : MonoBehaviour
{
    public GameObject panel1; // Panel actual que quieres desactivar
    public GameObject panel2; // Panel que quieres activar

    // M�todo para llamar al presionar el bot�n
    public void SwitchPanels()
    {
        // Desactiva el primer panel
        if (panel1 != null)
            panel1.SetActive(false);

        // Activa el segundo panel
        if (panel2 != null)
            panel2.SetActive(true);
    }
}
