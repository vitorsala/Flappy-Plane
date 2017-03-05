using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GerenciadorDePartida : MonoBehaviour {

    public enum EstadoDaPartida {
        INICIANDO, JOGANDO, PAUSADO, FRACASSADO
    }

    [HideInInspector]
    public EstadoDaPartida estado = EstadoDaPartida.INICIANDO;

    [HideInInspector]
    public int pontuacao = 0;

    public Button botaoRestart;
    public Text textoPontuacao;
    public Text textoInicio;

	// Use this for initialization
	void Start () {
        FindObjectOfType<ComponenteVoador>().delegado = JogadorColidiuComObstaculo;
        Time.timeScale = 0;
    }
	
	// Update is called once per frame
	void Update () {
        switch(estado) {
            case EstadoDaPartida.INICIANDO:
                if(Input.GetMouseButton(0)) {
                    Time.timeScale = 1f;
                    textoInicio.gameObject.SetActive(false);
                    estado = EstadoDaPartida.JOGANDO;
                }
                break;
            case EstadoDaPartida.JOGANDO:
                if(Time.timeScale != 1f)
                    Time.timeScale = 1f;

                break;
            case EstadoDaPartida.PAUSADO:
                if(Time.timeScale != 0f)
                    Time.timeScale = 0f;

                break;
            case EstadoDaPartida.FRACASSADO:
                MoverObjeto[] obstaculos = FindObjectsOfType<MoverObjeto>();
                foreach(MoverObjeto obs in obstaculos) {
                    obs.velocidade = Vector2.zero;
                }
                botaoRestart.gameObject.SetActive(true);
                FindObjectOfType<LoopDoBackground>().velocidadeDoScroll = 0f;
                Destroy(FindObjectOfType<GeradorDeObstaculos>());
                Destroy(FindObjectOfType<ComponenteVoador>());
                break;
        }
    }

    void JogadorColidiuComObstaculo() {
        estado = EstadoDaPartida.FRACASSADO;
    }

    public void JogadorPontuou() {
        pontuacao++;
        textoPontuacao.text = pontuacao.ToString();
    }
}
