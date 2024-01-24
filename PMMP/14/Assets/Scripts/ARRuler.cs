// ARRuler.cs

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARRuler : MonoBehaviour
{
    public ARRaycastManager arRaycastManager;
    public ARAnchorManager arAnchorManager;
    public GameObject measuringLinePrefab;

    private List<ARAnchor> anchors = new List<ARAnchor>();
    private Vector3 startPoint;
    private Vector3 endPoint;

    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                startPoint = hit.point;
            }
        }

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                endPoint = hit.point;
            }
        }

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            CreateMeasuringLine();
        }
    }

    void CreateMeasuringLine()
    {
        Vector3 midPoint = (startPoint + endPoint) / 2;
        float distance = Vector3.Distance(startPoint, endPoint);

        GameObject measuringLine = Instantiate(measuringLinePrefab, midPoint, Quaternion.LookRotation(endPoint - startPoint));
        measuringLine.transform.localScale = new Vector3(distance, 1f, 1f);

        ARAnchor anchor = arAnchorManager.AddAnchor(new Pose(midPoint, Quaternion.identity));
        anchors.Add(anchor);
    }
}
