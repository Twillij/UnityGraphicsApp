using UnityEngine;

public class PostProcessor : MonoBehaviour
{
    public Material postMat;
    public bool active = false;

    public void ToggleActive()
    {
        active = !active;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // if active, then render the image using the post processing material
        if (active)
        {
            Graphics.Blit(source, destination, postMat);
        }
        // otherwise render the image as normal
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
