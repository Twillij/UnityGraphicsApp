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
        // cycle through the material list
        matIndex = (matIndex + 1 < materials.Count) ? matIndex + 1 : 0;

        // set the target's material
        target.GetComponent<Renderer>().material = materials[matIndex];
    }

    private void Start()
    {
        if (!target)
            target = gameObject;
    }
}
