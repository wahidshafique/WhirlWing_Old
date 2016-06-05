using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Randomizer : MonoBehaviour {
    void Awake() {
        Random.seed = (int)System.DateTime.Now.Ticks;
        int childCount = this.transform.childCount;
        List<int> numLis = new List<int>(childCount);
        for (int j = 1; j <= childCount / 2; j++) {//populate animal dictionary with keys and values
            numLis.Add(j);//make the normal number list, doubled
            numLis.Add(j);
        };
        int iterator = 0;
        int randomEntry = Random.Range(0, numLis.Count);
        int randNumToUse = numLis[randomEntry];
        foreach (Transform child in transform) {
           // if (iterator % 2 == 0) {
                randomEntry = Random.Range(0, numLis.Count);
                randNumToUse = numLis[randomEntry];
           // } else {
                numLis.RemoveAt(randomEntry);//remove the used entry as to not overlap
          //  }
            Sprite spriteToUse = Resources.LoadAll<Sprite>("sprite_sheet_chart")[randNumToUse];//populate sprites via random num
            child.GetComponent<SpriteRenderer>().sprite = spriteToUse;
            iterator++;
        }
    }
}
