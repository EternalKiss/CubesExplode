using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _size;

    private float _spawnChance = 100;

    public float SpawnChance => _spawnChance;
    public float Size => _size;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        ColorChanger();
    }

    public void Initialize(float size, float spawnChance, Vector3 position)
    {
        _size = size;
        _spawnChance = spawnChance;

        transform.localScale = Vector3.one * size;
        transform.position = position;


    }

    private void ColorChanger()
    {
        Color color = Random.ColorHSV();
        _renderer.material.color = color;
    }
}
