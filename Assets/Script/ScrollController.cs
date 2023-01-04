using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    public CanvasGroup listToping;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FadeOut()
    {
        listToping.alpha = 0;
    }
    void FadeIn()
    {
        listToping.alpha = 1;
    }
}
