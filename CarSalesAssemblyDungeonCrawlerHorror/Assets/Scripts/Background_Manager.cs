using UnityEngine;
using UnityEngine.UI;

public class Background_Manager : MonoBehaviour
{
    public Image image;
    public Sprite current_Image;

    public void Start()
    {
        current_Image = image.sprite;
    }

    public void Change_Background(Sprite new_Sprite)
    {
        image.sprite = new_Sprite;
        current_Image = new_Sprite;
    }
}
