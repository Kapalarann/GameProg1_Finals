using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.PlayerSettings;

public class GemGenerator : MonoBehaviour
{

    private MeshFilter meshFilter;

    [SerializeField] int gemCount;

    [SerializeField] List<Gem> gems = new List<Gem>();
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        generateGems();
    }

    private Mesh mesh;
    private Vector3[] vertices;
    private int frequency;
    private void generateGems()
    {
        mesh = meshFilter.sharedMesh;
        vertices = mesh.vertices;
        Vector3 pos = meshFilter.transform.position;

        frequency = vertices.Length/gemCount;

        int rand = 0;
        for(int i = 0; i < vertices.Length; i+= frequency)
        {
            rand = Random.Range(0, gems.Count);
            Instantiate(gems[rand].gameObject, pos + vertices[i] - (Vector3.up * gems[rand].depth), Quaternion.identity);
        }
    }

    [System.Serializable]
    class Gem
    {
        public GameObject gameObject;
        public float depth;
    }
}
