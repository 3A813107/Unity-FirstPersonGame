using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{
    LaunchGrenade launchGrenade;
    LineRenderer lineRenderer;

    public int numPoints = 50;
    public float timeBetweenPoint = 0.1f;

    public LayerMask CollidableLayers;
    // Start is called before the first frame update
    void Start()
    {
        launchGrenade = GetComponent<LaunchGrenade>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount=numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = launchGrenade.spawnPoint.position;
        Vector3 startingVelocity = launchGrenade.spawnPoint.up * launchGrenade.throwFoece;
        for(float t=0;t < numPoints;t += timeBetweenPoint)
        {
            Vector3 newPoint = startingPosition + t*startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t * Physics.gravity.y/2 * t * t;
            points.Add(newPoint);       

            if(Physics.OverlapSphere(newPoint,2,CollidableLayers).Length > 0)
            {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }

        lineRenderer.SetPositions(points.ToArray());
    }
}
