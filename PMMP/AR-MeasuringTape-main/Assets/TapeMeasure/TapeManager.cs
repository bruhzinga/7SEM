using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class TapeManager : MonoBehaviour
{
    ARRaycastManager aRRaycastManager;

    public GameObject[] tapePoints;
    public GameObject reticle;

    float distanceBetweenPoints = 0f;

    public TMP_Text distanceText;

    public TMP_Text floatingDistanceText;
    public GameObject floatingDistanceObject;

    public LineRenderer line;
    
    bool placementEnabled = true;

    Unit currentUnit = Unit.m;

    public enum TapeState
    {
        None,
        OnePointPlaced,
        TwoPointsPlaced
    }

    TapeState currentState = TapeState.None;

    void Start()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        UpdateDistance();
        PlaceFloatingText();
        PerformRaycast();
    }

    void PerformRaycast()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon);

        if (hits.Count > 0)
        {
            reticle.transform.position = hits[0].pose.position;
            reticle.transform.rotation = hits[0].pose.rotation;
            if (currentState == TapeState.OnePointPlaced)
            {
                DrawLine();
            }
            if (!reticle.activeInHierarchy && currentState != TapeState.TwoPointsPlaced)
            {
                reticle.SetActive(true);
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && currentState != TapeState.TwoPointsPlaced)
            {
                PlacePoint(hits[0].pose.position);
                placementEnabled = false;
            }
            else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                placementEnabled = true;
            }
        }
        else if (hits.Count == 0 || currentState == TapeState.TwoPointsPlaced)
        {
            reticle.SetActive(false);
        }
    }

    public void PlacePoint(Vector3 pointPosition)
    {
        tapePoints[(int)currentState].SetActive(true);
        tapePoints[(int)currentState].transform.position = pointPosition;
        tapePoints[(int)currentState].AddComponent<ARAnchor>();
        if (currentState == TapeState.None)
        {
            currentState = TapeState.OnePointPlaced;
        }
        else if (currentState == TapeState.OnePointPlaced)
        {
            currentState = TapeState.TwoPointsPlaced;
        }
    }

    void UpdateDistance()
    {
        if (currentState == TapeState.None)
        {
            distanceBetweenPoints = 0f;
        }
        else if (currentState == TapeState.OnePointPlaced)
        {
            distanceBetweenPoints = Vector3.Distance(tapePoints[0].transform.position, reticle.transform.position);
        }
        else if (currentState == TapeState.TwoPointsPlaced)
        {
            distanceBetweenPoints = Vector3.Distance(tapePoints[0].transform.position, tapePoints[1].transform.position);
        }

        float convertedDistance = 0f;

        switch (currentUnit)
        {
            case Unit.m:
                convertedDistance = distanceBetweenPoints;
                break;
            case Unit.cm:
                convertedDistance = distanceBetweenPoints * 100;
                break;
            default:
                break;
        }

        string distanceStr = convertedDistance.ToString("#.##") + currentUnit;

        distanceText.text = distanceStr;
        floatingDistanceText.text = distanceStr;
    }

    void DrawLine()
    {
        line.enabled = true;
        line.SetPosition(0, tapePoints[0].transform.position);
        if (currentState == TapeState.OnePointPlaced)
        {
            line.SetPosition(1, reticle.transform.position);
        }
        else if (currentState == TapeState.TwoPointsPlaced)
        {
            line.SetPosition(1, tapePoints[1].transform.position);
        }
    }

    void PlaceFloatingText()
    {
        if (currentState == TapeState.None)
        {
            floatingDistanceObject.SetActive(false);
        }
        else
        {
            floatingDistanceObject.SetActive(true);
            Vector3 midPoint;
            if (currentState == TapeState.OnePointPlaced)
            {
                midPoint = Vector3.Lerp(tapePoints[0].transform.position, reticle.transform.position, 0.5f);
            }
            else
            {
                midPoint = Vector3.Lerp(tapePoints[0].transform.position, tapePoints[1].transform.position, 0.5f);
            }
            floatingDistanceObject.transform.position = midPoint;
        }

        floatingDistanceObject.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);
    }

    public void ChangeUnit(string unit)
    {
        currentUnit = (Unit)System.Enum.Parse(typeof(Unit), unit);
    }
}

public enum Unit 
{
    m,
    cm,
}
