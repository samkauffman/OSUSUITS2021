using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ProgressBar : MonoBehaviour
{
    public float percentage;
    public GameObject variableBar;
    public GameObject background;

    public TMP_Text pressureText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        percentage = Mathf.Clamp(percentage, 0.0f, 1.0f);
        variableBar.transform.localScale = new Vector3(percentage/2.0f, variableBar.transform.localScale.y, 
                                                                variableBar.transform.localScale.z);
        variableBar.transform.localPosition = new Vector3(-background.transform.localScale.x / 2.0f + percentage/4.0f, variableBar.transform.localPosition.y,
                                                        variableBar.transform.localPosition.z);

        pressureText.text = "Pressure: " + Mathf.RoundToInt(percentage * 100f) + "%";
    }
}
