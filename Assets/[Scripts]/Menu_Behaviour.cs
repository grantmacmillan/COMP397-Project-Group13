using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Behaviour : MonoBehaviour
{

    Material m;
    void Start()
    {
        m = GetComponent<Renderer>().material;
        
    }

    void OnMouseEnter()
    {
        m.color = Color.yellow;
    }

    void OnMouseExit()
    {
        m.color = Color.white;
    }
}
