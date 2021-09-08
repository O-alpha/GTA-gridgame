using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour 
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
 
    public void Init(bool isOffset)
    {
        _renderer.color = isOffset == true? _offsetColor : _baseColor;
        //Debug.Log(_renderer.color);
    }
 
    void OnMouseEnter() {
        _highlight.SetActive(true);
    }
 
    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
