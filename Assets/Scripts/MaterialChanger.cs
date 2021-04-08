using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public GameObject target;
    public List<Material> materials;

    private int matIndex = 0;

    public void SwitchMaterial()
    {
        matIndex = (matIndex + 1 < materials.Count) ? matIndex + 1 : 0;

        target.GetComponent<Renderer>().material = materials[matIndex];
    }

    private void Start()
    {
        if (!target)
            target = gameObject;
    }
}
