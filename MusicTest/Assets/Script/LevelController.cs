using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelController : MonoBehaviour {

    public GameObject[] points;
    public float timeBetweenPoints;
    public float pointsSpeed;
    List<GameObject> pointsList = new List<GameObject>();

    Camera mainCamera;   

    private void Start()
    {
        mainCamera = Camera.main;

        StartCoroutine(PointsCreation());
    }
    

    IEnumerator PointsCreation()
    {
        //Create a new list copying the arrey
        for (int i = 0; i < points.Length; i++)
        {
            pointsList.Add(points[i]);
        }
        yield return new WaitForSeconds(10);
        while (true)
        {
            ////choose random object from the list, generate and delete it
            int randomIndex = Random.Range(0, pointsList.Count);
            GameObject newPlanet = Instantiate(pointsList[randomIndex]);
            pointsList.RemoveAt(randomIndex);
            //if the list decreased to zero, reinstall it
            if (pointsList.Count == 0)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    pointsList.Add(points[i]);
                }
            }
            newPlanet.GetComponent<DirectMoving>().speed = pointsSpeed;

            yield return new WaitForSeconds(timeBetweenPoints);
        }
    }
}
