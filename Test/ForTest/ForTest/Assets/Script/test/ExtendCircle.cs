using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendCircle : MonoBehaviour
{
    public CircleCollider2D circleCollider2D;
    public new ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem.ShapeModule psShape = particleSystem.shape;
        circleCollider2D.radius = psShape.radius;
    }
}
