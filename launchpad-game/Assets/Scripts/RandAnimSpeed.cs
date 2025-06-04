using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandAnimSpeed : MonoBehaviour
{
    private Animator anim;

    void Start(){ 
        anim = GetComponent<Animator>();
        anim.speed = Random.Range(.75f, 1.25f);
    }
}
