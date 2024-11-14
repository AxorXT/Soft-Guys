using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControladordeNiveles : MonoBehaviour
{
    // Start is called before the first frame update
    public void  CambiarNivel(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);    
    }

    public void CambiarNivel(int numeroNivel)
    {
        SceneManager.LoadScene (numeroNivel);
    }


}
