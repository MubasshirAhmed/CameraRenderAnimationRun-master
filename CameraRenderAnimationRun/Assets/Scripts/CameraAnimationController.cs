using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationController : MonoBehaviour
{
    private List<GameObject> _inGameObjects = new List<GameObject>();
    private GameObject[] _objectsList;
    private Renderer[] _rend;

    private void Start()
    {
        _objectsList = GameObject.FindGameObjectsWithTag("AnimatedObject");
        for (int i = 0; i < _objectsList.Length; i++)
        {
            _rend[i] = _objectsList[i].GetComponent<Renderer>();
        }
    }

    void Update()
    {
        FindObjectsByTag();
    }

    void FindObjectsByTag()
    {
        _inGameObjects.Clear();
        for (int i = 0; i < _objectsList.Length; i++)
        {
            if (IsVisibleByTag(_objectsList[i])/*objectsList[i].GetComponent<Renderer>().isVisible*/)
            {
                _inGameObjects.Add(_objectsList[i].transform.parent.gameObject);
                _objectsList[i].GetComponentInParent<Animator>().enabled = true;
            }
            else
                _objectsList[i].GetComponentInParent<Animator>().enabled = false;
        }
        // debug console
        string result = "Total TagObj = " + _objectsList.Length + ".  Visible Renderers = " + _inGameObjects.Count;
        foreach (GameObject go in _inGameObjects)
            result += "\n " + go.name;

        Debug.Log(result);
    }

    bool IsVisibleByTag(GameObject go)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        return (GeometryUtility.TestPlanesAABB(planes, go.GetComponent<Renderer>().bounds)) ? true : false;
    }
}
