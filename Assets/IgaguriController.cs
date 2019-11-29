using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgaguriController : MonoBehaviour
{
    public void Shoot(Vector3 dir)
        //Shootは関数。他のスクリプトからアクセスするからpublic修飾子。
        //関数内でVector3型の、変数dirを仮引数として代入する。
    {
        GetComponent<Rigidbody>().AddForce(dir);
        //Rigidbody特有の機能を使えるようにして、
        //その中のAddForceを使用する。引数に入れる下記のVector3の方向に力を加える。
    }

    void OnCollisionEnter(Collision other)
        //OnCollisionEnterは、当たったタイミングでスクリプトの内容が呼ばれる関数。
    {
        GetComponent<Rigidbody>().isKinematic = true;
        //kinematicは運動という意味だが、これがtrueになることで物理影響を受けなくなる
        GetComponent<ParticleSystem>().Play();
        //ParticleSystemの機能を使えるようにして、その中のPlayメソッドを使用する
    }

    void Start()
    {
        //Shoot(new Vector3(0, 200, 2000));
        //上記の関数を使っている。引数の方向に力を加える。
        //Y方向に200の力が加わっているのは、的に届くまでに重力で落下するのを防ぐため
    }

    void Update()
    {
        
    }
}
