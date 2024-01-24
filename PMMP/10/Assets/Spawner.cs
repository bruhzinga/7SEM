using UnityEngine;
using UnityEngine.Rendering;

public class Spawner : MonoBehaviour
{
    public GameObject killbox;
    public GameObject greenPlatform;
    public float spawnInterval = 2f;
    public  float greenPlatformInterval = 5f;

    void Start()
    {
        // InvokeRepeating calls the SpawnObject method with the specified interval
        InvokeRepeating("SpawnKillBox", 0f, spawnInterval);
        InvokeRepeating("SpawnGreenPlatform", 0f, Random.Range(greenPlatformInterval,greenPlatformInterval+5));
    }

    void SpawnKillBox()
    {
        // Get the bounds of the plane
        Bounds planeBounds = GetPlaneBounds();

        // Get a random point within the bounds of the plane
        Vector3 spawnPoint = GetRandomSpawnPoint(planeBounds);

        // Instantiate the object at the random spawn point
        Instantiate(killbox, spawnPoint, Quaternion.identity);
    }

    void SpawnGreenPlatform()
    {
        // Get the bounds of the plane
        Bounds planeBounds = GetPlaneBounds();

        // Get a random point within the bounds of the plane
        Vector3 spawnPoint = GetRandomSpawnPoint(planeBounds);

        // Get the size of the green platform
        Vector3 platformSize = greenPlatform.transform.localScale;

        // Adjust the spawn point to ensure the platform fits within the boundary
        spawnPoint.x = Mathf.Clamp(spawnPoint.x, planeBounds.min.x + platformSize.x / 2, planeBounds.max.x - platformSize.x / 2);
        spawnPoint.z = Mathf.Clamp(spawnPoint.z, planeBounds.min.z + platformSize.z / 2, planeBounds.max.z - platformSize.z / 2);
        spawnPoint.y = planeBounds.max.y;

        // Instantiate the green platform at the adjusted spawn point
        Instantiate(greenPlatform, spawnPoint, Quaternion.identity);
    }

    Bounds GetPlaneBounds()
    {
        // Assuming the plane is a flat surface at y = 0
        Collider planeCollider = GetComponent<Collider>();

        if (planeCollider != null)
        {
            return planeCollider.bounds;
        }
        else
        {
            Debug.LogError("No collider found on the plane!");
            return new Bounds(Vector3.zero, Vector3.zero);
        }
    }

    Vector3 GetRandomSpawnPoint(Bounds bounds)
    {
        // Calculate a random point within the bounds of the plane
        float randomX = Random.Range(bounds.min.x - 5, bounds.max.x);
        float randomZ = Random.Range(bounds.min.z - 5, bounds.max.z);

        // Use the plane's y-coordinate or adjust it as needed
        float spawnY = Random.Range(transform.position.y + 20, transform.position.y + 30);

        // Create a random spawn point based on the calculated coordinates
        Vector3 randomSpawnPoint = new Vector3(randomX, spawnY, randomZ);

        return randomSpawnPoint;
    }
}
