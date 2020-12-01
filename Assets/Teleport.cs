using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // shoot a raycast from the center of our screen
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit; // output variable to get what we collided against
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform != null)
            {
                // set our location to the point we hit
                Vector3 newLocation = new Vector3(hit.point.x, 1, hit.point.z);
                transform.position = newLocation;
            }
        }
    }
}