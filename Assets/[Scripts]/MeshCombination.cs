using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombination : MonoBehaviour
{
    void Start()
    {
        CombineMeshes();
    }

    private void CombineMeshes()
    {
        var meshFilter = transform.GetComponent<MeshFilter>();
        meshFilter.mesh = new Mesh { indexFormat = UnityEngine.Rendering.IndexFormat.UInt32 };

        List<MeshFilter> meshFilters = new List<MeshFilter>(); // all mesh filters from the tiles

        for (int x = 0; x < transform.childCount; x++) {
            meshFilters.Add(transform.GetChild(x).GetComponent<MeshFilter>());
            transform.GetChild(x).GetComponent<MeshRenderer>().enabled = false;
        }

        CombineInstance[] combine = new CombineInstance[meshFilters.Count];

        int i = 0;
        
        while (i < meshFilters.Count)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                
            i++;
        }
       

        meshFilter.mesh.CombineMeshes(combine);
        transform.GetComponent<MeshCollider>().sharedMesh = meshFilter.sharedMesh;
    }
}
