using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopToggleImage : MonoBehaviour
{
    Image image;
    public Sprite chestOpen;
    public Sprite chestClosed;
    
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ImageToggle()
    {
        if (image.sprite == chestOpen)
        {
            FindObjectOfType<Sound_Manager>().Play("ShopButton");
            image.sprite = chestClosed;
        }
        else
        {
            FindObjectOfType<Sound_Manager>().Play("ShopButton");
            image.sprite = chestOpen;
        }
    }
}
