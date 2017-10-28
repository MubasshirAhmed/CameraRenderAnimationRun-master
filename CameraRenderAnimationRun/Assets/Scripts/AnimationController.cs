using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private void OnBecameVisible()
    {
        print("Visible");
        //GetComponent<Animator>().enabled = true;
        //GetComponentInParent<Animator>().enabled = true;
        gameObject.transform.parent.GetComponent<Animator>().enabled = true;

    }
    private void OnBecameInvisible()
    {
        print("Invisible");
        //GetComponent<Animator>().enabled = false;
        //GetComponentInParent<Animator>().enabled = false;
        gameObject.transform.parent.GetComponent<Animator>().enabled = false;
    }
}
