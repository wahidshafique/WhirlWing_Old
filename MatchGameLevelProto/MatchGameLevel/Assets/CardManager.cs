using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CardManager : MonoBehaviour { //quick and dirty match method
    public static int score;
    public static int clicks;
    private static List<SpriteRenderer> tuple = new List<SpriteRenderer>();
    private bool canClick = true;
    private AudioClip pop;

    SpriteRenderer sprite;

    void Start() {
        pop = Resources.Load("pop") as AudioClip;
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        clicks = 0;
        score = 0;
        tuple.Clear();
    }

    void HandleClicks() {
        GameObject.Find("BlueJay").GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("North America Animals")[2];//just to visual it
        if (canClick) {
            AudioSource.PlayClipAtPoint(pop, Vector3.zero);
            clicks++;
            print("the score is " + score);
            if (clicks <= 2) {
                tuple.Add(this.gameObject.GetComponent<SpriteRenderer>());
                if (clicks == 2) {
                    if (tuple[0].sprite.name == tuple[1].sprite.name && tuple[0].name != tuple[1].name) {
                        score++;
                        GameObject.Find("BlueJay").GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("North America Animals")[3];
                        canClick = false;//disable the matching cards!
                        tuple[0].GetComponent<CardManager>().canClick = false;
                        tuple.Clear();
                        clicks = 0;
                        if (score == 3)
                            Application.LoadLevel(Application.loadedLevel);
                    } else {
                        StartCoroutine("Wait");
                    }
                }
                sprite.sortingOrder = 2;
            }
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(1f);
        tuple[0].sortingOrder = 0;
        tuple[1].sortingOrder = 0;
        print("CLEAR");
        tuple.Clear();
        clicks = 0;
    }

    void OnMouseDown() {
        HandleClicks();
    }
}
