using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]
public class ScrubberScript : MonoBehaviour {
	BoxCollider2D coll;
    Vector2 origSize;
	// Use this for initialization
	void Start () {
		coll = this.GetComponent<BoxCollider2D> ();
        origSize = coll.size;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1")) {
            Vector3 mosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.gameObject.transform.position = mosPos;
		}
        //print(Input.GetAxis("Mouse X"));
        //if (Input.GetAxis("Mouse X") > 20 || Input.GetAxis("Mouse X") < -20) {
        //    coll.size = new Vector2(1.2f, 1.2f);
        //    print("FASST");
        //}
        if (Input.GetAxis("Mouse X") > 10 || Input.GetAxis("Mouse X") < -10) {
            coll.size = new Vector2(5.2f, origSize.y);
        } else if (Input.GetAxis("Mouse Y") > 5 || Input.GetAxis("Mouse Y") < -5) {
            coll.size = new Vector2(origSize.x, 5.2f);

        } else {
            coll.size = origSize;
        }
	}
}

