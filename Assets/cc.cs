
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class cc : MonoBehaviour
{
    public bool Blocked;
    public LayerMask Layers;
    public Transform T;
   
    public Button N;
    private int score;
    void Start()
    {
        Button btn = N.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        score = score + 1;
    }
    void Update()
    {
        if (score == 1)
        {
            Vector3 Location_Left_click = T.position;//Get the location where the user left clicked

            this.transform.position = T.position;//change the end point to the where the mouse clicked


        }
       
    }
}

