using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using UnityEngine;

public class NoiseVocelMap : MonoBehaviour
{
    [Header("blockPrefab")]
    public GameObject blockPrefabDirt;
    public GameObject blockPrefabGrass;
    public GameObject blockPrefabWater;
    public GameObject blockPrefabTree;

    public int width = 20;

    public int depth = 20;

    public int maxHeight = 16;    //y

    public int waterLevel = 4;

    [SerializeField] float noiseScale = 20f;

    // Start is called before the first frame update
    void Start()
    {

        float offsetX = Random.Range(-9999f, 9999f);
        float offsetZ = Random.Range(-9999f, 9999f);

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                float nx = (x + offsetX) / noiseScale;           //맵이 부드럽게 나오기 위해 나누어줌
                float nz = (z + offsetZ) / noiseScale;
                float nosie = Mathf.PerlinNoise(nx, nz);
                int h = Mathf.FloorToInt(nosie * maxHeight);
                if (h <= 0) h = 1;
                for ( int y = 0; y<= h; y++)
                {
                    if (y == h)
                        PlaceGrass(x, y, z);
                    else
                        PlaceDirt(x, y, z);
                }
                for (int y = h + 1; y <= waterLevel; y++)
                {
                    PlaceWater(x, y, z);
                }
            }
        }

        for ( int x = 0; x < width; x++)
        {
             for (int z = 0; z < depth; z++)
            {
                float nx = (x + offsetX);
                float nz = (z + offsetZ);
                float noise = Mathf.PerlinNoise(nx, nz);
                if ( noise < 0.2)
                {

                    PlaceTree(x, maxHeight, z);
                }
                
            }
        }

       

    }

    private void PlaceWater(int x, int y, int z)
    {
        var go = Instantiate(blockPrefabWater, new Vector3(x, y, z), Quaternion.identity, transform);
        go.name = $"Water_{x},{y},{z}";
    }

    private void PlaceDirt(int x, int y, int z)
    {
        var go = Instantiate(blockPrefabDirt, new Vector3(x, y, z), Quaternion.identity, transform);
        go.name = $"Dirt_{x},{y},{z}";
    }

    private void PlaceGrass(int x, int y, int z)
    {
        var go = Instantiate(blockPrefabGrass, new Vector3(x, y, z), Quaternion.identity, transform);
        go.name = $"Grass_{x},{y},{z}";
    }

    private void PlaceTree(int x, int y, int z)
    {
        var go = Instantiate(blockPrefabTree, new Vector3(x, y, z), Quaternion.identity, transform);
        go.name = $"Tree_{x},{y},{z}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
