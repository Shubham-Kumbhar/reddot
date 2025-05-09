using UnityEngine;
public class RedDot : MonoBehaviour
{
    private Vector3 targetPosition;
    private float moveSpeed = 1.5f;
    private float reachThreshold = 0.1f;
    private float moveRange = 3f; // how far each random move can be

    private GameObject currentZone;

    private void Start()
    {
        GameManager.Instance.redDots.Add(this);
        PickNewTarget();
    }

    private void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) <= reachThreshold)
        {
            PickNewTarget();
        }
    }

    void PickNewTarget()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-moveRange, moveRange),
            0f,
            Random.Range(-moveRange, moveRange)
        );

        targetPosition = transform.position + randomOffset;
    }

    public void SpawnZone(GameObject zonePrefab)
    {
        if (currentZone != null) return;

        currentZone = Instantiate(zonePrefab, transform.position, Quaternion.identity);
    }

    public void ClearZone()
    {
        if (currentZone != null)
        {
            Destroy(currentZone);
            currentZone = null;
        }
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.redDots.Remove(this);
    }
}