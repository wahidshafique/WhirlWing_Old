using UnityEngine;
using System.Collections;

public class ButtonColorPick : MonoBehaviour {
    public Color pickedColor = Color.black; //default is black
    //values based on pdf
    public void PickBlue() {
        pickedColor = new Color32(45, 183, 229, 255);
    }
    public void PickYellow() {
        pickedColor = new Color32(255, 186, 0, 255);
    }
    public void PickGreen() {
        pickedColor = new Color32(178, 203, 89, 255);
    }
    public void PickPurple() {
        pickedColor = new Color32(173, 72, 137, 255);
    }
    public void PickPink() {
        pickedColor = new Color32(254, 174, 174, 255);
    }
    public void PickOrange() {
        pickedColor = new Color32(227, 86, 17, 255);
    }
}
