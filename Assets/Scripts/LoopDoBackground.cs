using UnityEngine;
using System.Collections;

public class LoopDoBackground : MonoBehaviour {

    public float velocidadeDoScroll;
    public float quantidade;

    private Vector3 startPosition;
    // Use this for initialization
    void Start() {
        this.startPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        float newPosition = Mathf.Repeat(Time.timeSinceLevelLoad * velocidadeDoScroll, quantidade);
        transform.position = startPosition + Vector3.left * newPosition;
    }

}
