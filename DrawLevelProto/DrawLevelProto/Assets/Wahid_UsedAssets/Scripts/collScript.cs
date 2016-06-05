using UnityEngine;
using System.Collections;
[RequireComponent (typeof(BoxCollider2D))]
public class collScript : MonoBehaviour {
	static int collCount;
    Animator gatorAnim;
    Animator jayAnim;
	bool turnedOn = false;
    bool win;
    [SerializeField]
    GameObject gator;
    [SerializeField]
    GameObject jay;
    void Start() {
        collCount = 0;
        gatorAnim = gator.GetComponent<Animator>();
        jayAnim = jay.GetComponent<Animator>();
    }
	void OnTriggerEnter2D(Collider2D coll){
		//each prefab node has this and shares a static collCount
		//Once the count reaches a certain number (children of parented NodeHolder).len
		//The end sequence triggers
		if (!turnedOn) {
			if (coll.gameObject.tag == "Scrubber") {
				collCount++;
				print ("Nodes Touched: " + collCount);
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
				turnedOn = true;
				int countChildren = transform.parent.childCount;
                if (collCount == countChildren) {
                    gatorAnim.SetBool("Win", true);
                    jayAnim.SetBool("Win", true);
                    print("WINRAR~~~~!!!!!!");
                }
			}
		}
	}
}
