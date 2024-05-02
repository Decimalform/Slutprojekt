using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScript : MonoBehaviour
{
    public List<Sprite> portraits;
    public Image portrait;

    // Start is called before the first frame update
    void Start()
    {
        portrait = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
