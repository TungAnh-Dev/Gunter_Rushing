using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] float disLimit = 70f;
    float distance;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    // protected virtual void LoadCamera()
    // {
    //     if (this.mainCam != null) return;
    //     this.mainCam = Transform.FindObjectOfType<Camera>().transform;
    //     Debug.Log(transform.parent.name + ": LoadCamera", gameObject);
    // }

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCam.transform.position);
        if (this.distance > this.disLimit) return true;
        return false;
    }

}