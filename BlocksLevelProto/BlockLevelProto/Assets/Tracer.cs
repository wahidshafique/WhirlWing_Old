using UnityEngine;
using System;
using System.Collections;

public class Tracer : MonoBehaviour {
    public static int count = 0;
    [SerializeField]
    Collider2D playerCollider;
	// Use this for initialization

	void OnTriggerStay2D(Collider2D collider) {
        if (collider == playerCollider) count++;
        print(count);
        print("go");
    }
}
