using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Draw : MonoBehaviour {
    private LineRenderer line;
    public bool isMousePressed;
    private List<Vector3> pointsList;
    private Vector3 mousePos;
    public GameObject canvas;
    public Color selectedCol;
    static int index;
    // Structure for line points
    struct myLine {
        public Vector3 StartPoint;
        public Vector3 EndPoint;
    };

    void Start() {
        selectedCol = GameObject.Find("ColorPicker").GetComponent<ButtonColorPick>().pickedColor;
        //print(index);
        index++;
        //just testing out contraints here, no real mem issues occur with lots of lines
        if (index >= 50) {
            for (int i = 0; i < 40; i++) {
                Destroy(GameObject.Find("Brush(Clone)"));
            }
        }
        // Create line renderer component and set its property
        line = gameObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Mobile/Particles/Alpha Blended"));//can change to round edges w/ custom blend
        line.SetVertexCount(0);
        line.SetWidth(0.3f, 0.5f);
        line.SetColors(selectedCol, selectedCol);
        line.useWorldSpace = true;
        isMousePressed = false;
        pointsList = new List<Vector3>();
        line.sortingOrder = index; //stack lines over each other
    }
    void Update() {
        // If mouse button down, remove old line and set its color to green
        if (Input.GetMouseButtonDown(0)) {
            isMousePressed = true;
            line.SetVertexCount(0);
            pointsList.RemoveRange(0, pointsList.Count);
            line.SetColors(selectedCol, selectedCol);
        } else if (Input.GetMouseButtonUp(0)) {
            isMousePressed = false;
            line.SetColors(selectedCol, selectedCol);
            Destroy(this.GetComponent<Draw>());
			//this.GetComponent<CircleCollider2D>().offset = -1000;
            GameObject.Instantiate(Resources.Load("Brush"));
        }
        // Drawing line when mouse is moving(presses)
        if (isMousePressed) {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            if (!pointsList.Contains(mousePos)) {
                pointsList.Add(mousePos);
                line.SetVertexCount(pointsList.Count);
                line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);
            }
        }
    }
}
//removed intersection