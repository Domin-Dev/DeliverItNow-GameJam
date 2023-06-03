using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Error : MonoBehaviour
{
    Text text;
    Animator animator;

    void Start()
    {
        text = transform.GetComponentInChildren<Text>();
        animator = GetComponent<Animator>();
    }

    public void SetError(string errorText)
    {
        text.text = errorText;
        animator.SetTrigger("Error");    
    }

}
