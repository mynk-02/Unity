using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetSpawning : MonoBehaviour
{
    public GameObject Respawned_Object;
    //public GameObject Ground;
    public GameObject Crate;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "SpawningGround")
        {
            Vector3 Cposition = Crate.transform.position;
            Destroy(Crate);
            GameObject.Instantiate(Respawned_Object);
            Respawned_Object.transform.position = Cposition;
        }
        
    }
}
