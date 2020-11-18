using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedData : MonoSingleton<SharedData>
{
    public Transform cellParent;
    public Texture cellTickedTexture;
    public Texture cellClearTexture;
    public GridData data;
    public int maxGridCountForSafety;
}