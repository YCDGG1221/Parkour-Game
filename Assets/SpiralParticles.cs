using UnityEngine;

public class SpiralParticles : MonoBehaviour
{
    public ParticleSystem ps;
    public float spiralSpeed = 2.0f;
    public float riseSpeed = 0.5f;
    public float radius = 1.0f;
    
    private ParticleSystem.Particle[] particles;

    void LateUpdate()
    {
        if (ps == null) return;

        int particleCount = ps.particleCount;
        if (particles == null || particles.Length < particleCount)
        {
            particles = new ParticleSystem.Particle[particleCount];
        }

        ps.GetParticles(particles);

        for (int i = 0; i < particleCount; i++)
        {
            // 交替讓粒子起始相位不同，形成雙螺旋
            float phaseOffset = (i % 2 == 0) ? 0 : Mathf.PI; // 0 或 π 使它們相差半圈
            float angle = Time.time * spiralSpeed + i * 0.2f + phaseOffset;

            particles[i].position = new Vector3(
                Mathf.Cos(angle) * radius,  
                particles[i].position.y + (riseSpeed * Time.deltaTime),  
                Mathf.Sin(angle) * radius   
            );
        }

        ps.SetParticles(particles, particleCount);
    }
}

