using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.InputSystem;

public class SliceObject : MonoBehaviour
{

    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator;

    public LayerMask sliceableLayer;

    public Material crossSectionMaterial;
    public float cutForce = 2000;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }
    }
    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3  planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();
        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);

        if(hull != null)
        {

            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
            SetupSlicedComponent(upperHull);
            upperHull.layer = target.layer;
            GameObject lowerhull = hull.CreateLowerHull(target, crossSectionMaterial);
            SetupSlicedComponent(lowerhull);
            lowerhull.layer = target.layer;
            Destroy(target);
        }
    }
    public void SetupSlicedComponent(GameObject sliceObject)
    {
        Rigidbody rb = sliceObject.AddComponent<Rigidbody>();
        MeshCollider collider = sliceObject.AddComponent<MeshCollider>();
        collider.convex = true;
        rb.AddExplosionForce(cutForce, sliceObject.transform.position, 1);


    }
}
