using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]

public class Wave : ScriptableObject
{
    public int skeleton;
    public int orc;
    public int vampire;
    

    public Wave(int skeleton, int orc, int vampire) {
        this.skeleton = skeleton;
        this.orc = orc;
        this.vampire = vampire;
        
    }
}
