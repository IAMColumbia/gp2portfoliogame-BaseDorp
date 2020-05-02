using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindPickup : MonoBehaviour
{
    [SerializeField]
    public float rewindAmount = 50;
    [SerializeField]
    float respawnTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        Invoke("Respawn", respawnTime);
    }

    void Respawn()
    {
        this.gameObject.SetActive(true);
    }
}
