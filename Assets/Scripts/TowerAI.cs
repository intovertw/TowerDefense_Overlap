using UnityEngine;
using System.Collections;

public class TowerAI : MonoBehaviour
{
    Collider[] hits;
    bool kill;

    void Start()
    {
        kill = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 0f);
        if(hits[0])
        Gizmos.DrawRay(transform.position, hits[0].transform.position - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        hits = Physics.OverlapSphere(transform.position, 6f);

        if (kill && hits[0] != null)
        {
            Debug.Log("You can't escape!");
            StartCoroutine(KillEnemy());
            kill = false;
        }
    }

    IEnumerator KillEnemy()
    {
        Debug.Log("This will hurt.");

        Destroy(hits[0].gameObject);

        Debug.Log("Destroy!");

        yield return new WaitForSeconds(3);
        kill = true;
    }
}
