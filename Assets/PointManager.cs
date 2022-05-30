using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{

    [SerializeField] private GameObject pointsGameObject;

    private List<GameObject> points = new List<GameObject>();

    private List<bool> selectedPoints = new List<bool>();
    private int randomRange = 7;

    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject activator;

    private int numberOfPortals;
    private int numberOfKeys;



    // Start is called before the first frame update
    void Start()
    {
        GetPoints();

        numberOfKeys = GameManager.instance.numberOfKeys;
        numberOfPortals = GameManager.instance.numberOfPortals;

        ChoosePoints();

    }

    private void GetPoints()
    {
        for (int i = 0; i < pointsGameObject.transform.childCount; i++)
        {
            points.Add(pointsGameObject.transform.GetChild(i).gameObject);
            selectedPoints.Add(false);
        }
    }

    private void ChoosePoints()
    {
        for(int i = 0; i < numberOfPortals; i++)
        {
            int index = ChoosePoint();
            Instantiate(spawner, points[index].transform.position, points[index].transform.rotation, points[index].transform);
            selectedPoints[index] = true;

        }
        for (int i = 0; i < numberOfKeys; i++)
        {
            int index = ChoosePoint();
            Instantiate(activator, new Vector3(points[index].transform.position.x, points[index].transform.position.y - 1.5f, points[index].transform.position.z), points[index].transform.rotation, points[index].transform);
            selectedPoints[index] = true;
        }
    }

    private int ChoosePoint()
    {
        int random = Random.Range(0, selectedPoints.Count);

        if (selectedPoints[random])
        {
            return ChoosePoint();
        }

        return random;
    }

}
