using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleToggle : MonoBehaviour
{
    public GameObject[] _go; //The objects to be toggled. Should NOT be the object containing this code
    public bool isVisible = true; //The state of the object's visibility
    public bool isVisibleAtStart = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject gi in _go)
        {
            gi.SetActive(isVisibleAtStart);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject gi in _go)
        {
            gi.SetActive(isVisible);
        }
    }

    public void Toggle()
    {
        //Toggles the state of the gameObject
        isVisible = !isVisible;
        foreach (GameObject gi in _go)
        {
            gi.SetActive(isVisible);
        }
    }

    public void SetVisible(bool visibleStatus)
    {
        isVisible = visibleStatus;
        //Set the visibility from a value
        foreach (GameObject gi in _go)
        {
            gi.SetActive(visibleStatus);
        }
    }

}
