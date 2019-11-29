using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgaguriGenerator : MonoBehaviour
{
    public GameObject igaguriPrefab;
    //igaguriPrefabの箱を用意しておく。ここではまだ箱だけ
    //アウトレット接続により、スクリプト内の変数にオブジェクト（igaguriPrefab)の実態を代入する
    //スクリプト側にコンセントの差し込み口をつくるために、変数の前にpublic修飾子をつける
    //これにより、インスペクタから変数が見えるようになり、代入したいオブジェクト（igaguriPrefab）をアタッチできる

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject igaguri = Instantiate(igaguriPrefab) as GameObject;
            //Instantiateは、クローンのオブジェクトを生成するメソッド
            //Instantiateメソッドは、引数に設計図を渡すと、戻り値としてインスタンスを返す
            //GameObject型の変数igaguriを定義して、上記でできたインスタンスを代入している
            //as GameObjectは、キャストという強制的な型変換。
            //InstantiateはObject型で返すのでそれをGameObject型にしている

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //ScreenPointToRayは、カメラからタップ座標に向かうベクトルに沿って進むRay（光線）を返すメソッド
            Vector3 worldDir = ray.direction;
            //Rayクラスは、光源の座標（origin）と、光線の方向（direction）、をメンバ変数に持っている
            //directionは、カメラからタップした座標に向かうベクトル
            igaguri.GetComponent<IgaguriController>().Shoot(worldDir.normalized * 2000);
            //生成したオブジェクトに対して動きを付与している
            //IgaguriControllerのスクリプトを取得し、その関数のShootメソッドを使用している
            //normalizedは、worlddirを長さ１の単位ベクトルに変換した後、一定の力を加えるため2000倍している

        }
    }
}
