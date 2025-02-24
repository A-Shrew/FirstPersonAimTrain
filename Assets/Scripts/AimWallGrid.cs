using Unity.VisualScripting;
using System;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;
using System.Security.Cryptography;

public class AimWallGrid : MonoBehaviour
{
    public static int width = 10, height = 5;
    [SerializeField] private Transform gridLocation;
    [SerializeField] private GameObject tile;
    [SerializeField] private GameObject target;
    private GameObject[,] wallGrid = new GameObject[width,height];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateWall();
        SpawnBall();
    }

    // Update is called once per frame
    public void GenerateWall()
    {
        for(int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                wallGrid[i,j] = Instantiate(tile, new Vector3(gridLocation.position.x+i, gridLocation.position.y+j, gridLocation.position.z), Quaternion.identity);       
            }
        }
    }

    public void SpawnBall()
    {
        System.Random rand = new System.Random();
        float randomPosX = rand.Next(0, width);
        float randomPosY = rand.Next(0, height);
        Instantiate(target, new Vector3(gridLocation.position.x + randomPosX, gridLocation.position.y + randomPosY, gridLocation.position.z), Quaternion.identity);
    }
}
