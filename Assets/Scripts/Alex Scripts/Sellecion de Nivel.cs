using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string targetSceneName; // Nombre de la escena a la que se va a cambiar
    [SerializeField] private GameObject panelToDisable; // Panel que se desactivar� en la nueva escena
    [SerializeField] private GameObject panelToEnable;  // Panel que se activar� en la nueva escena

    // M�todo que cambia de escena al presionar el bot�n
    public void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (panelToDisable != null)
            panelToDisable.SetActive(false);

        if (panelToEnable != null)
            panelToEnable.SetActive(true);

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
