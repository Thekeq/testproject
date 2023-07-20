using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour
{
    public int health = 4;

    private GatherResources GR;
    public GameObject logPrefab;

    private void Start()
    {
        GR = FindObjectOfType<GatherResources>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GR.Shoot();
            StartCoroutine(HitResourceWithDelay());
        }
    }
    private IEnumerator RespawnTree(GameObject tree)
    {
        yield return new WaitForSeconds(15f);
        gameObject.SetActive(true);
    }
    private IEnumerator HitResourceWithDelay()
    {
        yield return new WaitForSeconds(2f);
        DestroyTree();
    }
    private void DestroyTree()
    {
        gameObject.SetActive(false);
        SpawnLogPrefab(transform.position);
        GR.StartCoroutine(RespawnTree(gameObject));
    }
    private void SpawnLogPrefab(Vector3 position)
    {
        Instantiate(logPrefab, position, Quaternion.identity);
    }
}
