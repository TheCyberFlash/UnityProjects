using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : MonoBehaviour
{
    private float range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameVisible()
    {
        var tower = gameObject.GetComponentInParent<Tower>();
        range = tower.range;
        transform.localScale = new Vector3(range, range, 0);
    }
}
