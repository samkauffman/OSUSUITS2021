using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public bool Blocked;
    public LayerMask Layers;
    public Transform O_Point;

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
           
           
                this.transform.position = O_Point.position;//change the end point to the where the mouse clicked

            
        }

    }
}

