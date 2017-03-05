using UnityEngine;
using System.Collections;

public class AutoDestruidor : MonoBehaviour {

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
