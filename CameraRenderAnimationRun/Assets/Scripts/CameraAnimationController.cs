using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationController : MonoBehaviour
{
    private List<GameObject> inGameObjects = new List<GameObject>();
    GameObject[] objectsList;

    private void Start()
    {
        objectsList = GameObject.FindGameObjectsWithTag("AnimatedObject");
    }

    void Update()
    {

        FindObjectsByTag();
    }

    void FindObjectsByTag()
    {
        inGameObjects.Clear();
        for (int i = 0; i < objectsList.Length; i++)
        {
            if (IsVisibleByTag(objectsList[i])/*objectsList[i].GetComponent<Renderer>().isVisible*/)
            {
                inGameObjects.Add(objectsList[i].transform.parent.gameObject);
                objectsList[i].GetComponentInParent<Animator>().enabled = true;
            }
            else
                objectsList[i].GetComponentInParent<Animator>().enabled = false;
        }
        // debug console
        string result = "Total TagObj = " + objectsList.Length + ".  Visible Renderers = " + inGameObjects.Count;
        foreach (GameObject go in inGameObjects)
            result += "\n " + go.name;

        Debug.Log(result);
    }

    bool IsVisibleByTag(GameObject go)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        return (GeometryUtility.TestPlanesAABB(planes, go.GetComponent<Renderer>().bounds)) ? true : false;
    }
}
