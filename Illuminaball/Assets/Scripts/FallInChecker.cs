using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInChecker : MonoBehaviour
{
    public Hole red;
    public Hole blue;
    public Hole green;

    private void OnGUI() {
        string label = " ";

        //すべのボールが入ったらラベルを表示
        if(red.IsFallIn() && blue.IsFallIn() && green.IsFallIn()) {
            label = "Fall in hole!";
        }
        GUI.Label(new Rect(0, 0, 100, 30), label);
    }
}
