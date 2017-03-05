using UnityEngine;
using System.Collections;

public class MoverObjeto : MonoBehaviour {

    [HideInInspector]
    public Vector2 velocidade = Vector2.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = gameObject.transform.position + new Vector3(velocidade.x, velocidade.y, 0);
    }
}
