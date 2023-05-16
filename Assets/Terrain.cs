using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;

    protected int horizontalSize; 

    public virtual void Generate(int size)
    {
        horizontalSize = size;

        if(size == 0)
        return;

        if((float) size % 2 == 0)
            size -= 1;

        int moveLimit = Mathf.FloorToInt(f: (float) size / 2);

        for (int i = -moveLimit; i <= moveLimit; i++)
        {
            SpawnTile(i);
        }

        var leftBoundaryTile = SpawnTile(-moveLimit -1);
        var rightBoundaryTile = SpawnTile(moveLimit +1);

        DarkenObject(leftBoundaryTile);
        DarkenObject(rightBoundaryTile);
    }
    private GameObject SpawnTile(int xPos)
    {
        var go = Instantiate (original: tilePrefab, parent: transform);

        go.transform.localPosition = new Vector3(xPos, 0, 0);

        return go;       
    }

    private void DarkenObject(GameObject go)
    {
        var renderers = go.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
        foreach (var rend in renderers)
        {
            rend.material.color =  rend.material.color * Color.grey;
        }
    }
}
