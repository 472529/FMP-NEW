using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField]
    Player p;

    [SerializeField]
    PickupController pickupController;

    [SerializeField]
    GameObject gunContainer;
    
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gunContainer = GameObject.FindGameObjectWithTag("GunContainer");
        
    }
    private void Update()
    {
        pickupController = gunContainer.GetComponentInChildren<PickupController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            p.isLoadScene = true;
            pickupController.Sceneloaded();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
}
