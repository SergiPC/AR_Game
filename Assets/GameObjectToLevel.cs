using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectToLevel : MonoBehaviour {

    public GameObject linked_object;
    public bool block_rotation = false;
    bool active = true;
	// Use this for initialization
	void Awake ()
    {
    }
	

	void Update ()
    {
        if(linked_object.activeInHierarchy)
        {
            if (!active)
            {
                OnActivate();
                active = true;
            }
                
            transform.position = linked_object.transform.position;
            ProjectTransformOnPlane(transform, transform.parent.gameObject.transform.parent.position, transform.parent.gameObject.transform.parent.up);
            //transform.localPosition = new Vector3(transform.localPosition.x, 0.0f, transform.localPosition.z);
            if (!block_rotation)
            {
                transform.rotation = linked_object.transform.rotation;
                transform.localRotation = Quaternion.Euler(90.0f, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
            }
            
        }
        else
        {
            if (active)
            {
                OnDeactivate();
                active = false;
            }
        }
        
    }

    private void ProjectTransformOnPlane(Transform objectToProject, Vector3 planeOrigin, Vector3 planeNormal)
    {
        Plane projectionPlane = new Plane(planeNormal, planeOrigin);
        float distanceToIntersection;
        Vector3 dir = Camera.main.transform.position - transform.position;
        Ray intersectionRay = new Ray(transform.position, dir);
        if (projectionPlane.Raycast(intersectionRay, out distanceToIntersection))
        {
            objectToProject.position = objectToProject.position + dir.normalized * distanceToIntersection;
        }
    }


    void OnActivate()
    {
        Renderer[] ren = GetComponentsInChildren<Renderer>(true);

        foreach (Renderer component in ren)
        {
            component.enabled = true;
        }

        Collider[] col = GetComponentsInChildren<Collider>(true);

        foreach (Collider component in col)
        {
            component.enabled = true;
        }

        MonoBehaviour[] mon = GetComponentsInChildren<MonoBehaviour>(true);

        foreach (MonoBehaviour component in mon)
        {
            component.enabled = true;
        }
    }

    void OnDeactivate()
    {
        Renderer[] ren = GetComponentsInChildren<Renderer>(true);

        foreach (Renderer component in ren)
        {
            component.enabled = false;
        }

        Collider[] col = GetComponentsInChildren<Collider>(true);

        foreach (Collider component in col)
        {
            component.enabled = false;
        }

        MonoBehaviour[] mon = GetComponentsInChildren<MonoBehaviour>(true);

        foreach (MonoBehaviour component in mon)
        {
            if(component != this)
                component.enabled = false;
        }
    }
}
