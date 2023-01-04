using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScaleObjectDot : MonoBehaviour
{
    public float dur;
    public Vector3 scale;
    
    void Start()
    {
        this.gameObject.transform.DOScale(scale, dur).SetLoops(-1,LoopType.Yoyo); 
    }
}
