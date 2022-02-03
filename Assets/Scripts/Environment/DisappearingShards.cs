/*
 * Author: Alex Pham
 * Contributors:
 * Description: Displays animation for disappearing shards.
 */
using UnityEngine;

public class DisappearingShards : MonoBehaviour
{
    // private fields
    private Material[] _currentMaterials;
    private Color _insideMeshColor;
    private Color _outsideMeshColor;
    private float _currentAlpha;
    private float _desiredAlpha;
    private float _timeRemaining;
    private float _disappearTime;
    
    void Start()
    {
        _currentMaterials = GetComponent<Renderer>().materials;
        _insideMeshColor = _currentMaterials[0].color;
        _outsideMeshColor = _currentMaterials[1].color;
        _currentAlpha = 1;
        _desiredAlpha = 0;
        _timeRemaining = 1.2f;
        _disappearTime = _timeRemaining - .1f;
    }
    
    void Update()
    {
        _timeRemaining -= Time.deltaTime;
        if (_timeRemaining <= 0)
        {
            destroyParent();
        }
        if (_timeRemaining <= _disappearTime )
        {
            GetComponent<MeshCollider>().isTrigger = true;
        }
        _currentAlpha = Mathf.MoveTowards(_currentAlpha, _desiredAlpha, 1.0f * Time.deltaTime);
        _insideMeshColor.a = _currentAlpha;
        _outsideMeshColor.a = _currentAlpha;
        _currentMaterials[0].color = _insideMeshColor;
        _currentMaterials[1].color = _outsideMeshColor;
    }

    void destroyParent()
    {
        Destroy(transform.parent.gameObject);
    }
}
