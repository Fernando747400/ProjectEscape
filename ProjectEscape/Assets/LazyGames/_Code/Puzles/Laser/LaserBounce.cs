using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBounce : MonoBehaviour
{
    int maxBounce = 5;
    private LineRenderer lr;
    [SerializeField]
    public Transform startPoint;
    [SerializeField]
    public bool reflectOnlyMirror;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, startPoint.position);
    }

    void Update()
    {
        CastLaser(transform.position, transform.forward);
    }

    void CastLaser(Vector3 position, Vector3 direction)
    {
        lr.SetPosition(0, startPoint.position);

        for(int i = 0; i < maxBounce; i++)
        {
            Ray ray = new Ray(position, direction);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 300, 1))
            {
                position = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
                lr.SetPosition(i + 1, hit.point);

                if(hit.transform.name != "Mirror" && reflectOnlyMirror)
                {
                    for(int j = (i + 1); j <= 5; j++)
                    {
                        lr.SetPosition(j, hit.point);
                    }
                    break;
                }
            }
        }
    }
}
