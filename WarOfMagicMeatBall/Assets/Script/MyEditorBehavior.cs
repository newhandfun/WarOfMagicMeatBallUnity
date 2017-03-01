using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEditorBehavior : MonoBehaviour {

    [SerializeField]
    protected bool isDestroyOnAwake = true;

    void Awake() {
        if (isDestroyOnAwake) {
            Destroy(this.gameObject);
        }
        Destroy(this);
    }
}
