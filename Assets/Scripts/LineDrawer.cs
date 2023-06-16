using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    private const int MinNumberOfPointsInLine = 2;
    
    [SerializeField] private GameObject _linePrefabs;
    [SerializeField] private LayerMask _cantDrawOverLayerMask;
    [SerializeField] private float _linePointsMinDistance;
    [SerializeField] private float _lineWidth;
    [SerializeField] private Gradient _lineColor;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _lineWithFactor = 3f;

    private int _cantDrawOverLayerIndex;
    private Line _currentLine;

    private void Start()
    {
        int layerNumber = Mathf.RoundToInt(Mathf.Log(_cantDrawOverLayerMask.value, 2));
        _cantDrawOverLayerIndex = layerNumber;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BeginDraw();
        }

        if (_currentLine != null)
        {
            Draw();
        }

        if (Input.GetMouseButtonUp(0))
        {
            EndDraw();
        }
    }

    private void BeginDraw()
    {
        _currentLine = Instantiate(_linePrefabs, this.transform).GetComponent<Line>();
        
        _currentLine.SetLineColor(_lineColor);
        _currentLine.SetLineWidth(_lineWidth);
        _currentLine.SetPointMinDistance(_linePointsMinDistance);
        _currentLine.UsePhysics(false);
    }

    private void Draw()
    {
        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.CircleCast(mousePosition, _lineWidth / _lineWithFactor, Vector2.zero, 1f, _cantDrawOverLayerMask);

        if (hit)
        {
            EndDraw();
        }
        else
        {
            _currentLine.AddPoint(mousePosition);
        }
    }

    private void EndDraw()
    {
        if (_currentLine != null)
        {
            if (_currentLine.PointsCount < MinNumberOfPointsInLine)
            {
                Destroy(_currentLine.gameObject);
            }
            else
            {
                _currentLine.gameObject.layer = _cantDrawOverLayerIndex;
                _currentLine.UsePhysics(true);
                _currentLine = null;
            }
        }
    }

}
