using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    [Header("Prefabs references")]
    [Tooltip("Temporary hex prefab. In future read proper hex model from some sort of stored data.")]
    public GameObject hexPrefab;
    [Space]
    [Header("Grid Settings")]
    [Tooltip("Hexagonal grid width. Number of hexagons along x axis.")]
    public int gridWidth;
    [Tooltip("Hexagonal grid height. Number of hexagons along z axis.")]
    public int gridHeight;
    [Tooltip("Hex outer radius. Spacing between hexes center points along z axis")]
    public float hexOuterRadius;
    //Spacing between hexes center points. Along x axis. Value based on hexOuterRadius.
    private float hexInnerRadius;

    private void Start()
    {
        hexInnerRadius = hexOuterRadius * 0.866025404f;
        DrawHexGrid();
    }

    private void DrawHex(int _x, int _z) 
    {
        Vector3 position;
        position.x = (_x + _z * 0.5f - _z / 2) * hexInnerRadius * 2f;
        position.y = 0f;
        position.z = _z * hexOuterRadius * 1.5f;

        GameObject hex = Instantiate(hexPrefab, transform, false);
        hex.transform.localPosition = position;
    }

    private void DrawHexGrid() 
    {
        for (int z = 0; z < gridHeight; z++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                DrawHex(x, z);
            }
        }
    }
}
