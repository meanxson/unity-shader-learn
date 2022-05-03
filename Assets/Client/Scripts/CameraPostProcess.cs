using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPostProcess : MonoBehaviour
{
    [field: SerializeField] public Shader Shader { get; private set; }

    private Material _material;

    private void Awake()
    {
        _material = new Material(Shader);
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, _material);
    }
}
