using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TerrainTeraformer : MonoBehaviour
{
    [SerializeField] LayerMask terrainLayer;
    [SerializeField] Camera playerCamera;
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject laser;

    [SerializeField] float playerReach;
    [SerializeField] float laserStrength;
    [SerializeField] float laserSize;

    public GemUI gemUI;

    private MeshFilter meshFilter;
    private MeshCollider meshCollider;
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();
    }

    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, playerReach, terrainLayer)) {
                TerraformTerrain(hit.point, -laserStrength * Time.deltaTime, laserSize);
            }
            laser.SetActive(true);
        }
        else
        {
            laser.SetActive(false);
        }

        if (Input.GetMouseButton(1) && Physics.Raycast(ray, out hit, playerReach, terrainLayer))
        {
            TerraformTerrain(hit.point, laserStrength * Time.deltaTime, laserSize);
        }

        if (laserStrength != 1 + (gemUI.gemCount / 10))
        {
            laserStrength = 1 + (gemUI.gemCount / 10);
            laserSize = 1 + (gemUI.gemCount / 10);
        }
    }

    private Mesh mesh;
    private Vector3[] vertices;
    private void TerraformTerrain(Vector3 pos, float height, float range)
    {
        mesh = meshFilter.sharedMesh;
        vertices = mesh.vertices;
        pos -= meshFilter.transform.position;

        int i = 0;
        foreach(Vector3 v in vertices)
        {
            float dist = Vector2.Distance(new Vector2(v.x, v.z), new Vector2(pos.x, pos.z));
            if (dist <= range)
            {
                vertices[i] = v + new Vector3(0f, height * (1- ( (dist/range) * (dist / range))), 0f);
            }
            i++;
        }

        mesh.vertices = vertices;
        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;
    }
}
