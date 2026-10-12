using UnityEngine;
using System.Collections.Generic;

public class Blade : MonoBehaviour
{
    public GameObject bladeTrailPrefab;
    public bool isCutting = false;
    public float minCuttingVelocity = .001f;
    Vector3 previousPosition;
    GameObject currentBladeTrail;
    Rigidbody rb;
    Camera cam;
    SphereCollider sphereCollider;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();

        // ВАЖНО: Делаем коллайдер лезвия триггером
        if (sphereCollider != null)
        {
            sphereCollider.isTrigger = true;
            sphereCollider.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }
        if (isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        Vector3 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude / Time.deltaTime;
        if (velocity > minCuttingVelocity)
        {
            sphereCollider.enabled = true;
        }
        else
        {
            sphereCollider.enabled = false;
        }
        previousPosition = newPosition;
    }

    void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        previousPosition.z = 0;
        sphereCollider.enabled = false;
    }

    void StopCutting()
    {
        isCutting = false;
        if (currentBladeTrail != null)
        {
            currentBladeTrail.transform.SetParent(null);
            Destroy(currentBladeTrail, 2f);
        }
        sphereCollider.enabled = false;
    }

    private HashSet<GameObject> alreadySliced = new HashSet<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (isCutting && other.CompareTag("Fruit"))
        {
            // Проверяем, не резали ли мы уже этот объект
            if (!alreadySliced.Contains(other.gameObject))
            {
                alreadySliced.Add(other.gameObject);
                ScoreManager.AddScore(10);
                Destroy(other.gameObject);
            }
        }
    }
}
