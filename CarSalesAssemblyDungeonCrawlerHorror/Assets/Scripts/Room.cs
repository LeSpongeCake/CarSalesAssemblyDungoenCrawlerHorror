using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    public GameObject left;
    public GameObject right;
    public GameObject up;
    public GameObject down;
    public GameObject collectable;
    public bool collected;
    public Sprite background;
}
