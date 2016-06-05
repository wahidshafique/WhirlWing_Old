using UnityEngine;
using System.Collections;

public class ClickDrag : MonoBehaviour {
    private AudioClip wrongSound;
    private AudioClip dropSound;
    private AudioClip pickSound;
    private Vector3 startPos;
    private Vector3 silo;
    private float scalex;
    private float scaley;
    private float scalexTmp;
    private float scaleyTmp;
    private bool isClicked;
    public bool isBig = false;
    private bool matching = false;

    // Use this for initialization
    void Start() {
        pickSound = Resources.Load("pop") as AudioClip;//okay these are just placeholders -__-
        dropSound = Resources.Load("bird") as AudioClip;
        wrongSound = Resources.Load("bleg") as AudioClip;
        silo = GameObject.Find("Silo").transform.localScale;
        startPos = gameObject.transform.position;
        scalex = transform.localScale.x;
        scaley = transform.localScale.y;
        scalexTmp = scalex;
        scaleyTmp = scaley;
    }

    // Update is called once per frame
    void Update() {
        if (isClicked) {
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 temp = transform.position;
            temp.z = 10;
            transform.position = temp;
            if (scalexTmp <= silo.x && scaleyTmp <= silo.y) {
                scalexTmp += 0.002f;
                scaleyTmp += 0.002f;
                if (scalexTmp * scaleyTmp >= (silo.x * silo.y) - 0.01) {
                    print("episilon");
                    isBig = true;
                    if (!matching)
                        AudioSource.PlayClipAtPoint(wrongSound, Vector3.zero);
                    //StartCoroutine("wiggle"); //do wiggle in anim
                }
            }
            transform.localScale = new Vector3(scalexTmp, scaleyTmp, 1);
        } else {
            //StopCoroutine("wiggle");// routine showing false match should end
            gameObject.transform.position = startPos;
            transform.localScale = new Vector3(scalex, scaley, 1);
            scalexTmp = scalex;
            scaleyTmp = scaley;
        }
    }

    //IEnumerator wiggle() {
    //    // Vector3 rotVec = transform.rotation.eulerAngles;
    //    while (true) {
    //        //transform.Rotate(Vector3.forward, 1);
    //        //transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * 500, 30f));
    //        transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.realtimeSinceStartup * 10) * 10);
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == this.tag) {
            print("A MATCH!");
            matching = true;
            if (isBig)
                Application.LoadLevel(Application.loadedLevel);
        }
    }
    void OnMouseDown() {
        //ideation for sound effects?
        AudioSource.PlayClipAtPoint(pickSound, Vector3.zero);
        isClicked = true;
    }

    void OnMouseUp() {
        AudioSource.PlayClipAtPoint(dropSound, Vector3.zero);
        isClicked = false;
    }
}