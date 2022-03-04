using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonSizeWithPointer : MonoBehaviour
{
    public Button button;

    void Start()
    {
        button.GetComponent<Animator>().enabled = false;
    }
    
    public void OnPointerEnter()
    {
        button.GetComponent<Animator>().enabled = true;
        button.GetComponent<Animator>().SetBool("Expand", true);

    }

    public void OnPointerExit()
    {
        button.GetComponent<Animator>().enabled = true;
        button.GetComponent<Animator>().SetBool("Expand", false);

    }
}
