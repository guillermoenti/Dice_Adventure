using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WayPoint : MonoBehaviour
{
    GameObject canvas;

    [SerializeField] GameObject wPPrefab;

    private GameObject obj;

    private CanvasGroup wayPointGroup;
    private Image pyraWayPoint;
    private TextMeshProUGUI distanceText;



    RectTransform wayPointRect;
    GameObject player;

    [SerializeField]
    float minScale;

    [SerializeField]
    float maxScale;

    float scaleNum;
    float alphaNum;

    float minX, minY, maxX, maxY;

    float maxDistance = 75f;


    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("WayPointCanvas");
        obj = Instantiate(wPPrefab, canvas.transform.position, Quaternion.identity);
        obj.transform.SetParent(canvas.transform);

        wayPointGroup = obj.GetComponent<CanvasGroup>();
        pyraWayPoint = obj.transform.GetChild(0).GetComponent<Image>();
        distanceText = pyraWayPoint.transform.GetChild(0).GetComponent<TextMeshProUGUI>();


        wayPointRect = wayPointGroup.GetComponent<RectTransform>();

        minX = wayPointRect.rect.width / 2;
        maxX = Screen.width - minX;

        minY = wayPointRect.rect.height / 2;
        maxY = Screen.height - minY;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) >= 10f)
        {
            wayPointGroup.gameObject.SetActive(true);
            Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);

            if (Vector3.Dot(player.transform.position - transform.position, Camera.main.transform.forward) > 0)
            {
                if (pos.x < Screen.width / 2)
                {
                    pos.x = maxX;
                }
                else
                {
                    pos.x = minX;
                }
            }
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            CalculateAlpha();
            CalculateScale();

            wayPointGroup.transform.position = pos;
            distanceText.text = ((int)Vector3.Distance(player.transform.position, transform.position)).ToString() + "m";
        }
        else
        {
            wayPointGroup.gameObject.SetActive(false);
        }
    }

    void CalculateScale()
    {
        scaleNum = Vector3.Distance(player.transform.position, transform.position) / maxDistance;
        wayPointGroup.transform.localScale = Vector3.one * Mathf.Lerp(minScale, maxScale, scaleNum);
    }

    void CalculateAlpha()
    {
        alphaNum = Vector3.Distance(player.transform.position, transform.position) / maxDistance;
        wayPointGroup.alpha = Mathf.Lerp(0f, 1f, alphaNum);
    }
}
