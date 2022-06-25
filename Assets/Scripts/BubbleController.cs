using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BubbleController : MonoBehaviour
{
    [SerializeField]
    private float VerticalSpeed;
    [SerializeField]
    private float HorizontalSpeedDelta;
    [SerializeField]
    private float CorrectProbability;
    private Rigidbody2D _rigidbody2D;
    private TextMeshPro _textMeshPro;
    private bool exist;
    private bool correct;
    private Vector2 _targetVelocity;
    private float _delta = 0.01f;
    private BubbleLevelManagerController _bubbleLevelManager;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        exist = true;
        _textMeshPro = GetComponentInChildren<TextMeshPro>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _bubbleLevelManager = GameObject.FindObjectOfType<BubbleLevelManagerController>();
        correct = UnityEngine.Random.value < CorrectProbability;
        _rigidbody2D.velocity = new Vector2(0, -VerticalSpeed * _bubbleLevelManager.getSpeedModifier());
        _targetVelocity = new Vector2(HorizontalSpeedDelta * UnityEngine.Random.Range(-1f, 1f), _rigidbody2D.velocity.y);
        _textMeshPro.text = generateEquation(correct);
        _anim = GetComponent<Animator>();
    }

    private string generateEquation(bool correct)
    {
        int n1 = 0, n2 = 0, result = 0;
        char sign = '0';
        switch(UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sign = '*';
                n1 = UnityEngine.Random.Range(1, 10);
                n2 = UnityEngine.Random.Range(1, 10);
                result = n1 * n2;
                break;
            case 1:
                sign = '+';
                n1 = UnityEngine.Random.Range(1, 10);
                n2 = UnityEngine.Random.Range(1, 10);
                result = n1 + n2;
                break;
            case 2:
                sign = '÷';
                n2 = UnityEngine.Random.Range(1, 10);
                result = UnityEngine.Random.Range(1, 10);
                n1 = result * n2;
                break;
            case 3:
                sign = '-';
                n2 = UnityEngine.Random.Range(1, 10);
                result = UnityEngine.Random.Range(1, 10);
                n1 = result + n2;
                break;
        }
        if(!correct)
        {
            int newResult;
            newResult = UnityEngine.Random.Range(-5, 5);
            if (newResult >= 0)
                newResult++;
            if (result == 0 && newResult < 0)
                result++;
            result += newResult;
            if(result < 0)
                result = 0;
        }

        return $"{n1}{sign}{n2}={result}";
    }

    // Update is called once per frame
    void Update()
    {
        if (exist)
        {
            if (Math.Abs(_rigidbody2D.velocity.x - _targetVelocity.x) > _delta)
                _rigidbody2D.velocity = Vector2.Lerp(_rigidbody2D.velocity, _targetVelocity, 10 * Time.deltaTime);
            else
            {
                _targetVelocity = new Vector2(HorizontalSpeedDelta * UnityEngine.Random.Range(-1f, 1f), _rigidbody2D.velocity.y);
            }
        }
    }



    private void OnMouseDown()
    {
        if (exist && Time.deltaTime > 0)
        {
            exist = false;
            if (correct)
            {
                _bubbleLevelManager.GetComponent<AudioSource>().Play();
                _bubbleLevelManager.addScore();
            }  
            else
                _bubbleLevelManager.loseLife();
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
            _anim.SetBool("isBursted", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _targetVelocity.x *= -1;
        _rigidbody2D.velocity = new Vector2(-_rigidbody2D.velocity.x, _rigidbody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (correct)
            _bubbleLevelManager.loseLife();
        GameObject.Destroy(gameObject);
    }
}
