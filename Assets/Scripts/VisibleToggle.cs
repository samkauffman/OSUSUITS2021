using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleToggle : MonoBehaviour
{
    public GameObject _go; //The object to be toggled. Should NOT be the object containing this code
    public bool isVisible = true; //The state of the object's visibility

    // Start is called before the first frame update
    void Start()
    {
        if(_go == null) _go = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        _go.SetActive(isVisible);
    }

    public void Toggle()
    {
        //Toggles the state of the gameObject
        isVisible = !isVisible;
        _go.SetActive(isVisible);
    }
}
