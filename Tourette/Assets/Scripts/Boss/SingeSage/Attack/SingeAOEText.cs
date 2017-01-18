using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class SingeAOEText : MonoBehaviour {

    private TextMesh _Text;
    public float _Duration = 5.0f;
    private float _StartDuration;

    void Start()
    {
        _Text = GetComponent<TextMesh>();
        _StartDuration = _Duration;
        _Duration = 0.0f;
    }

    void Update()
    {
        if (_Duration < 2.0f)
        {
            _Text.color = Color.Lerp(new Color(1.0f, 0.22f, 0.0f, 0.0f), new Color(1.0f, 0.67f, 0F, 1.0f), _Duration);
        }
        else
        {
            _Text.color = Color.Lerp(new Color(1.0f, 0.67f, 0F, 1.0f), Color.clear, (_Duration - 2F) / (_StartDuration - 2F));
        }
        _Duration += Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up, 10 * Time.deltaTime);
    } 
}
