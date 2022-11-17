using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public GameObject Character = null;
    public GameObject Camera = null;
    public GameObject Sprite = null;

    public PC_Main Brain;

    public string Name { get; set; }
    public int ID { get; set; }
}
