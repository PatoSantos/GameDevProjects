using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrbs : MonoBehaviour
{
    public GameObject fireOrb, waterOrb, earthOrb, windOrb;
    Image fireOrbIm, waterOrbIm, earthOrbIm, windOrbIm;
    public string currentOrb = "";
    // Start is called before the first frame update
    void Start()
    {
        currentOrb = "";
        fireOrbIm = fireOrb.GetComponent<Image>();
        waterOrbIm = waterOrb.GetComponent<Image>();
        earthOrbIm = earthOrb.GetComponent<Image>();
        windOrbIm = windOrb.GetComponent<Image>();

        SetOpacity(fireOrbIm, 0f);
        SetOpacity(waterOrbIm, 0f);
        SetOpacity(earthOrbIm, 0f);
        SetOpacity(windOrbIm, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentOrb.Equals("fire"))
        {
            SetOpacity(fireOrbIm, 1f);
            SetOpacity(waterOrbIm, 0f);
            SetOpacity(earthOrbIm, 0f);
            SetOpacity(windOrbIm, 0f);
        } else if (currentOrb.Equals("water"))
        {
            SetOpacity(fireOrbIm, 0f);
            SetOpacity(waterOrbIm, 1f);
            SetOpacity(earthOrbIm, 0f);
            SetOpacity(windOrbIm, 0f);
        }
        else if (currentOrb.Equals("earth"))
        {
            SetOpacity(fireOrbIm, 0f);
            SetOpacity(waterOrbIm, 0f);
            SetOpacity(earthOrbIm, 1f);
            SetOpacity(windOrbIm, 0f);
        }
        else if (currentOrb.Equals("wind"))
        {
            SetOpacity(fireOrbIm, 0f);
            SetOpacity(waterOrbIm, 0f);
            SetOpacity(earthOrbIm, 0f);
            SetOpacity(windOrbIm, 1f);
        } else
        {
            SetOpacity(fireOrbIm, 0f);
            SetOpacity(waterOrbIm, 0f);
            SetOpacity(earthOrbIm, 0f);
            SetOpacity(windOrbIm, 0f);
        }
    }

    void SetOpacity(Image orbImage, float opacity)
    {
        orbImage.color = new Color(orbImage.color.r, orbImage.color.g, orbImage.color.b, opacity);
    }
}
