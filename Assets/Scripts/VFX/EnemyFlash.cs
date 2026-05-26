using UnityEngine;
using System.Collections;

public class EnemyFlash : MonoBehaviour
{
    public Renderer meshRenderer;

    public Material flashMaterial;

    private Material originalMaterial;

    void Start()
    {
        originalMaterial = meshRenderer.material;
    }

    public void Flash()
    {
        StartCoroutine(DoFlash());
    }

    IEnumerator DoFlash()
    {
        meshRenderer.material = flashMaterial;

        yield return new WaitForSeconds(0.08f);

        meshRenderer.material = originalMaterial;
    }
}
