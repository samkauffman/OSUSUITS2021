using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleArray : MonoBehaviour
{
    public GameObject[] objects;
    public bool[] active;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject go in objects)
        {
            go.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchActiveTo(int index)
    {
        foreach (GameObject go in objects)
        {
            go.SetActive(false);
        }
        objects[index].SetActive(true);
    }
}
