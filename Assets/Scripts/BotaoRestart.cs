using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BotaoRestart : MonoBehaviour {

    public void Reiniciar() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
