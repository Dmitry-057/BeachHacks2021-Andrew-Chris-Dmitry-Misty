using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    // array of background levels
    public GameObject[] levels;
    // main camera
    private Camera mainCamera;
    // bounds of screen
    private Vector2 screenBounds;
    public float choke;

    void Start() {   
        // get main camera
        mainCamera = gameObject.GetComponent<Camera>();
        // get screen bounds
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // loop through each object in levels array and load child objects
        foreach(GameObject obj in levels) {
            loadChildObjects(obj);
        }
    }
    
    // load child objects of a given object
    void loadChildObjects(GameObject obj) {
        // get the object width
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        // calculate how many childs will be needed based on the screen bounds
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);
        // create a clone of the object
        GameObject clone = Instantiate(obj) as GameObject;
        // for each child needed, instantiate that amount of childs
        for (int i = 0; i <= childsNeeded; i++) {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
        }
        // destroy the clone and object sprite renderer since we dont need them anymore
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    // repositions child objects
    void repositionChildObjects(GameObject obj) {
        // get Transform objects from every child
        Transform[] children = obj.GetComponentsInChildren<Transform>();

        // check if there is more than 1 child
        if (children.Length > 1) {
            // get the first child
            GameObject firstChild = children[1].gameObject;
            // get the last child
            GameObject lastChild = children[children.Length - 1].gameObject;
            // get half the width of the object
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;
            // if the x position of Transform plus the x value of screen bounds is greater than the last childs x position
            // plus the half width of the object then set the first child as last sibling
            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);

            }
            // else then set the last child as the first sibling
            else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth) {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);

            }
        }
    }

    // reposition child objects for each object in levels array
    void LateUpdate() {
        // reposition child objects for each object in levels
        foreach (GameObject obj in levels) {
            repositionChildObjects(obj);
        }
    }
}
