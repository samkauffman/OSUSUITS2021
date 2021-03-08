using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public bool Blocked;
    public LayerMask Layers;
    public Transform O_Point;
    public Transform p;
    public Button N;
    private int score;
    void Start()
    {
    Button btn = N.GetComponent<Button>();
    btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        score = score +  1;
    }
    void Update()
    {
        if (score == 1)
        {
            Vector3 Location_Left_click = O_Point.position;//Get the location where the user left clicked
           
                this.transform.position = O_Point.position;//change the end point to the where the mouse clicked

            
        }
        if (score == 2)
        {
            

            this.transform.position = p.position;//change the end point to the where the mouse clicked


        }
    }
}

