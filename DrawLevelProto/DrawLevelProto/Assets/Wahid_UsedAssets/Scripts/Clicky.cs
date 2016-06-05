using UnityEngine;
using System.Collections;

public class Clicky : MonoBehaviour {
    Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }
    void OnMouseDown() {
        print("clicked");
        anim.SetTrigger("Tapped");
    }

    //dirty reset 
    void Reset() {
        Application.LoadLevel(Application.loadedLevel);
    }
    
	
}
