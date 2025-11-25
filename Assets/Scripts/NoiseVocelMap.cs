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
    public GameObject blockPrefabCoal;
    public GameObject blockPrefabSteel;

    [Header("맵 정보")]
    public int width = 35;     //넓이
    public int depth = 35;     //깊이
    public int Height = 16;    //높이
    public int waterLevel = 4;    //물 생성 단위
    public int steelHeight = 7;    //철 생성 단위
    public int coalHeight = 3;

    public Block[,,] map;

    [SerializeField] float noiseScale = 20f;

    // Start is called before the first frame update
    void Start()
    {
        map = new Block[width, Height, depth];         //맵 빈 배열 생성

        float offsetX = Random.Range(-9999f, 9999f);
        float offsetZ = Random.Range(-9999f, 9999f);

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                float nx = (x + offsetX) / noiseScale;           //맵이 부드럽게 나오기 위해 나누어줌
                float nz = (z + offsetZ) / noiseScale;
                float nosie = Mathf.PerlinNoise(nx, nz);
                int h = Mathf.FloorToInt(nosie * Height);
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

        for (int x = 0; x < width; x++)
        {
             for (int z = 0; z < depth; z++)
             {
                float nx = (x + offsetX);
                float nz = (z + offsetZ);
                float noise = Mathf.PerlinNoise(nx, nz);
               
                if(noise < 0.2f)                              //나무 생성 조건
                {
                    for (int y = Height -1; y >= 0; y--)     //y 맨 위부터 내려오면서 확인
                    {
                        if (map[x,y,z] !=null && map[x,y,z].type != BlockType.Air)
                        {
                            PlaceTree(x, y + 1, z);
                            break;

                            
                        }
                    }
                }

                if (noise > 0.15f && noise < 0.3f)      //철 생성
                {
                   int y = steelHeight;

                    if( map[x,y,z] !=null && map[x,y,z].type == BlockType.Dirt)
                    {
                            Destroy(map[x, y, z].gameObject);
                            PlaceSteel(x, y, z);
                    }
                }

                if (noise > 0.13f && noise < 0.25f)     //석탄 생성     //범위 늘린 이유 : 안 늘리면 noise값 같아서 나무 아래에만 생성됨
                {
                    int y = coalHeight;
                    if (map[x, y, z] != null && map[x, y, z].type == BlockType.Dirt)
                    {
                        Destroy(map[x, y, z].gameObject);
                        PlaceCoal(x, y, z);
                    }
                }
                
             }
        }

       

    }

    private void PlaceWater(int x, int y, int z)
    {
        GameObject block = Instantiate(blockPrefabWater, new Vector3(x, y, z), Quaternion.identity, transform);
        block.name = $"Water_{x},{y},{z}";
        Block blockData = block.GetComponent<Block>();

        map[x, y, z] = blockData;    //블럭 데이터 저장

        Destroy(map[x, y, z].gameObject);          //오브젝트 삭제
        map[x, y, z] = null;                       //저장 데이터 삭제

        if (blockPrefabWater != null)
        {
            Instantiate(blockPrefabWater);
        }
    }

    private void PlaceDirt(int x, int y, int z)
    {
        GameObject block = Instantiate(blockPrefabDirt, new Vector3(x, y, z), Quaternion.identity, transform);
        block.name = $"Dirt_{x},{y},{z}";
        Block blockData = block.GetComponent<Block>();

        map[x, y, z] = blockData;    //블럭 데이터 저장

        Destroy(map[x, y, z].gameObject);          //오브젝트 삭제
        map[x, y, z] = null;                       //저장 데이터 삭제

        if (blockPrefabDirt != null)
        {
            Instantiate(blockPrefabDirt);
        }
    }

    private void PlaceGrass(int x, int y, int z)
    {
        GameObject block = Instantiate(blockPrefabGrass, new Vector3(x, y, z), Quaternion.identity, transform);
        block.name = $"Grass_{x},{y},{z}";
        Block blockData = block.GetComponent<Block>();

        map[x, y, z] = blockData;    //블럭 데이터 저장

        Destroy(map[x, y, z].gameObject);          //오브젝트 삭제
        map[x, y, z] = null;                       //저장 데이터 삭제

        if (blockPrefabGrass != null)
        {
            Instantiate(blockPrefabGrass);
        }
    }


    private void PlaceTree(int x, int y, int z)
    {
        GameObject block = Instantiate(blockPrefabTree, new Vector3(x, y, z), Quaternion.identity, transform);
        block.name = $"Tree_{x},{y},{z}";
        Block blockData = block.GetComponent<Block>();

        map[x, y, z] = blockData;    //블럭 데이터 저장

        Destroy(map[x, y, z].gameObject);          //오브젝트 삭제
        map[x, y, z] = null;

        if (blockPrefabTree != null)
        {
            Instantiate(blockPrefabTree);
        }
    }

    public void PlaceCoal(int x, int y, int z)
    {
        GameObject block = Instantiate(blockPrefabCoal, new Vector3(x, y, z), Quaternion.identity, transform);
        block.name = $"Coal_{x},{y},{z}";
        Block blockData = block.GetComponent<Block>();

        map[x, y, z] = blockData;

        Destroy(map[x, y, z].gameObject);
        map[x, y, z] = null;

        if (blockPrefabCoal != null)
        {
            Instantiate(blockPrefabCoal);
        }
    }

    public void PlaceSteel(int x, int y, int z)
    {
        GameObject block = Instantiate(blockPrefabSteel, new Vector3(x, y, z), Quaternion.identity, transform);
        block.name = $"Stee_{x},{y},{z}";
        Block blockData = block.GetComponent<Block>();

        map[x, y, z] = blockData;

        Destroy(map[x, y, z].gameObject);
        map[x, y, z] = null;

        if (blockPrefabSteel != null)
        {
            Instantiate(blockPrefabSteel);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
