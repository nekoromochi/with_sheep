using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCutin : MonoBehaviour
{
    [SerializeField]
    private GameObject parentWolfCutin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Destroy()
    {
        Destroy(parentWolfCutin);
    }
}
