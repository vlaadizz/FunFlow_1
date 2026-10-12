using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruitPrefab; // ���� ��������� Watermelon
    public float spawnInterval = 2f; // ������ 2 ������� ����� ������
    public float force = 10f; // ���� ������
    public float horizontalForce = 3f; // ���� ����

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnFruit();
            timer = 0;
        }
    }

    void SpawnFruit()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-3f, 3f), -5f, 0);
        GameObject fruit = Instantiate(fruitPrefab, spawnPos, Quaternion.identity);
        Rigidbody rb = fruit.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector3(
                Random.Range(-horizontalForce, horizontalForce),
                force,
                0
            );
        }
    }
}
