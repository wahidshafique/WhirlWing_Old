using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AnimalManager : MonoBehaviour {
    const int SPRITESHEETCUTS = 12; //how many splices are there in your sprite sheet

    private GameObject child;
    public GameObject silo;

    private static int lastSprite;
    private bool triggerSilo = true;
    private int childCount;

    private Dictionary<int, string> animals;
    //The animal images are pulled from a sprite sheet
    //the images are then tagged from a dictionary 
    void Start() {
        animals = new Dictionary<int, string>();
        Populate();
    }

    void Populate() {
        childCount = this.transform.childCount;
        List<int> numLis = new List<int>(childCount);
        List<int> usedLis = new List<int>(childCount);
        for (int j = 0; j < SPRITESHEETCUTS; j++) {//populate animal dictionary with keys and values
            animals.Add(j, ("ANIMAL" + j));
            numLis.Add(j);//make the normal number list
        }

        for (int i = 0; i < childCount; i++) {
            int randomEntry = Random.Range(0, numLis.Count);
            int randNumToUse = numLis[randomEntry];

            Sprite sprites = Resources.LoadAll<Sprite>("North America Animals")[randNumToUse];//populate sprites via random num
            child = this.gameObject.transform.GetChild(i).gameObject;
            child.GetComponent<SpriteRenderer>().sprite = sprites;
            child.tag = animals[randNumToUse];

            if ((Random.value > 0.7) || (i == childCount - 1) && triggerSilo) {
                if (randNumToUse != lastSprite) {
                    silo.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("North America Animals")[randNumToUse];
                    silo.tag = animals[randNumToUse];
                    triggerSilo = false;
                } else {
                    print("DOUBLING!!!!!!!!!!");
                }
                lastSprite = randNumToUse;
            }

            //usedLis.Add(randomEntry);//add the entry to used so the silouette can pick from the used sprites
            numLis.RemoveAt(randomEntry);//remove the used entry as to not overlap
        }
    }
}

