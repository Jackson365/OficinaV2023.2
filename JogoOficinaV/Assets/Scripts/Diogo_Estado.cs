using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diogo_Estado : MonoBehaviour
{
    public Diogo_Estado EstadoAtual;
    public float velocidadeRotacao;

    public List<Transform> firepoints;
    public float BossSpeed;
    public float TempoParaTiro;
    private float TempoAtualDoTiro;
    public GameObject Tiro;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateEstado1();
        if (EstadoAtual == Diogo_Estado.vidaAcabando)
        {
            updateEstado2();
        }

    }

    void updateEstado1()
    {
        transform.Rotate(velocidadeRotacao * Time.deltaTime * Vector3.forward);
        if (TempoAtualDoTiro >= TempoParaTiro)
        {
            TempoAtualDoTiro = 0;
            foreach (var VARIABLE in COLLECTION)
            {
                
            }
        }
    }
}
