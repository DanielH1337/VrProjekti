using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDisappearScript : MonoBehaviour
{
    private Material material;
    public bool isFading = false;
    // Start is called before the first frame update
    void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
    }


    // Update is called once per frame
    void Update()
    {
        if (isFading)
        {
            StartCoroutine(SlowFade());
            


        }
    }
    IEnumerator SlowFade()
    {
        yield return new WaitForSeconds(1f);
        Color c = material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            material.color = c;
            yield return new WaitForSeconds(0.2f);
        }
        gameObject.SetActive(false);

    }
}
