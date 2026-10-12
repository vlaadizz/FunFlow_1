using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject fruitSlicedPrefab;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Blade")
        {
            Vector3 direction = (col.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Instantiate(fruitSlicedPrefab, transform.position, rotation);
            Destroy(gameObject);
        }
    }
}