using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action Finished;
    
    private void Start()
    {
        LevelManager.Instance.SetPlayer(this);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Enemy enemy))
        {
            Finished?.Invoke();
        }
    }
}
