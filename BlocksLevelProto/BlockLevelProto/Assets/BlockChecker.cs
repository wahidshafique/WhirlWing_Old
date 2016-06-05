using UnityEngine;
using System.Collections;

public class BlockChecker : MonoBehaviour {
	void Update () {
	    if (Tracer.count == transform.childCount) {
            print("WINER");
        }
	}
}
