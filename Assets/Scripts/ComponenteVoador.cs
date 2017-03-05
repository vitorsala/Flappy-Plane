using UnityEngine;
using System.Collections;


public class ComponenteVoador : MonoBehaviour {

    public delegate void JogadorColidiuComObstaculo();

    [HideInInspector]
    public JogadorColidiuComObstaculo delegado;

    public float forca;

    void Update() {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        if(Time.timeScale != 0f && Input.GetMouseButtonDown(0)) {
            body.velocity = Vector2.zero;
            body.AddForce(new Vector2(0, forca));
        }
        float angulo = Mathf.Atan2(body.velocity.y, 2) * Mathf.Rad2Deg;
        body.transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Obstaculo")
            delegado();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Checkpoint")
            FindObjectOfType<GerenciadorDePartida>().JogadorPontuou();
    }
}
