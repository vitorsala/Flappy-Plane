using UnityEngine;
using System.Collections;

public class GeradorDeObstaculos : MonoBehaviour {

    public float velocidadeDosObstaculos = 1;

    public GameObject obstaculoMeio;
    public GameObject obstaculoPonta;

    public float tempoEntreObstaculos = 2;
    public float offset = 10;
    public float distancia = 100;

    float tempoDoUltimoObstaculo = 2;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        tempoDoUltimoObstaculo += Time.deltaTime;
        if(tempoDoUltimoObstaculo >= tempoEntreObstaculos) {

            tempoDoUltimoObstaculo = 0;

            CriarObstaculo(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + 5, Random.Range(offset, Screen.height - offset), 0f)));
        }
	}

    void CriarObstaculo(Vector3 posicao) {
        GameObject go = new GameObject();
        go.name = "Obstaculo";
        go.tag = "Checkpoint";

        BoxCollider2D body = go.AddComponent<BoxCollider2D>();
        body.isTrigger = true;
        body.size = new Vector2(0.1f, distancia);

        MoverObjeto componente = go.AddComponent<MoverObjeto>();
        componente.velocidade = new Vector2(-velocidadeDosObstaculos, 0);

        go.AddComponent<AutoDestruidor>();

        // Parte de cima dos obstaculos
        GameObject ponta = Instantiate(obstaculoPonta);
        ponta.tag = "Obstaculo";
        ponta.transform.SetParent(go.transform);
        ponta.transform.localScale = new Vector3(-1, -1, 1);
        ponta.transform.position = new Vector3(0, distancia / 2, 0);

        GameObject meio = Instantiate(obstaculoMeio);
        meio.tag = "Obstaculo";
        float alturaMeio = meio.GetComponent<SpriteRenderer>().bounds.size.y;
        meio.transform.SetParent(go.transform);
        meio.transform.position = new Vector3(0, ponta.transform.position.y + (alturaMeio / 2), 0);

        meio = Instantiate(obstaculoMeio);
        meio.tag = "Obstaculo";
        meio.transform.SetParent(go.transform);
        meio.transform.position = new Vector3(0, ponta.transform.position.y + (3 * alturaMeio / 2), 0);

        meio = Instantiate(obstaculoMeio);
        meio.tag = "Obstaculo";
        meio.transform.SetParent(go.transform);
        meio.transform.position = new Vector3(0, ponta.transform.position.y + (5 * alturaMeio / 2), 0);

        // Parte de baixo
        ponta = Instantiate(obstaculoPonta);
        ponta.tag = "Obstaculo";
        ponta.transform.SetParent(go.transform);
        ponta.transform.position = new Vector3(0, -(distancia / 2), 0);

        meio = Instantiate(obstaculoMeio);
        meio.tag = "Obstaculo";
        meio.transform.SetParent(go.transform);
        meio.transform.position = new Vector3(0, ponta.transform.position.y - (alturaMeio / 2), 0);

        meio = Instantiate(obstaculoMeio);
        meio.tag = "Obstaculo";
        meio.transform.SetParent(go.transform);
        meio.transform.position = new Vector3(0, ponta.transform.position.y - (3 * alturaMeio / 2), 0);

        meio = Instantiate(obstaculoMeio);
        meio.tag = "Obstaculo";
        meio.transform.SetParent(go.transform);
        meio.transform.position = new Vector3(0, ponta.transform.position.y - (5 * alturaMeio / 2), 0);

        Vector3 ponto = posicao;
        ponto.z = 0;

        go.transform.position = ponto;
    }
}
