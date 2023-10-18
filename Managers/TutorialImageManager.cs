using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialImageManager : MonoBehaviour
{
    public Sprite[] images;
    public Sprite curImage;
    public bool _onImage;

    public GameObject _imageCanvas;

    private static TutorialImageManager instance;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static TutorialImageManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void ChangeImage(int num)
    {
        _imageCanvas.SetActive(true);
        _onImage = true;
        _imageCanvas.transform.GetChild(0).GetComponent<Image>().sprite = images[num];
    }
}
