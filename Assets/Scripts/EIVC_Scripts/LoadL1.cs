using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class SceneLoader : MonoBehaviour
{
    // Este método puede ser llamado desde el botón
    public void LoadLevel1()
    {
        // Cambia "Level1" por el nombre exacto de tu escena
        SceneManager.LoadScene("Level1");
    }
}
