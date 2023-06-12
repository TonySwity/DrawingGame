using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Line : MonoBehaviour
{
    [SerializeField]private LineRenderer _lineRenderer;
    [SerializeField]private EdgeCollider2D _edgeCollider;
    [SerializeField]private Rigidbody2D _rigidbody2D;

    private List<Vector2> _points = new List<Vector2>();
    public int PointsCount = 0;

    private float _pointsMinDistance = 0.1f;
    private float _circleColliderRadius;
    
    public Vector2 GetLastPoint()
    {
        return (Vector2)_lineRenderer.GetPosition(PointsCount - 1); 
    }

    public void UsePhysics(bool usePhysic)
    {
        _rigidbody2D.isKinematic = !usePhysic;
    }

    public void SetLineColor(Gradient lineColor)
    {
        _lineRenderer.colorGradient = lineColor;
    }

    public void SetLineWidth(float width)
    {
        _lineRenderer.startWidth = width;
        _lineRenderer.endWidth = width;

        _edgeCollider.edgeRadius = width / 2f;
        _circleColliderRadius = width / 2f;
    }

    public void AddPoint(Vector2 newPoint)
    {
        if (PointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < _pointsMinDistance)
        {
            return;
        }
        
        _points.Add(newPoint);
        PointsCount++;

        CircleCollider2D circleCollider = this.gameObject.AddComponent<CircleCollider2D>(); 
        circleCollider.offset = newPoint;
        circleCollider.radius = _circleColliderRadius;

        _lineRenderer.positionCount = PointsCount;
        _lineRenderer.SetPosition(PointsCount - 1, newPoint);

        if (PointsCount > 1)
        {
            _edgeCollider.points = _points.ToArray();
        }
    }

    public void SetPointMinDistance(float distance)
    {
        _pointsMinDistance = distance;
    }
}
