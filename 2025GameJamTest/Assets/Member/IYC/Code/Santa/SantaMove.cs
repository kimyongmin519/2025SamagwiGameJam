using Member.KYM.Code.Interface;
using UnityEngine;
using Member.KYM.Code.Agent;

public class SantaMove : MonoBehaviour, IAgentComponent
{
    private Agent _agent;
    private Rigidbody2D _rigidbody2D;

    private float _xDir;
    private float _speed;

    public void Initialize(Agent agent)
    {
        _agent = agent;
        _rigidbody2D = agent.GetComponent<Rigidbody2D>();
    }

    public void SetXDir(float dir) => _xDir = dir;
    public void SetSpeed(float speed) => _speed = speed;

    private void FixedUpdate()
    {
        //_rigidbody2D.linearVelocityX = _xDir * _speed;
    }
}