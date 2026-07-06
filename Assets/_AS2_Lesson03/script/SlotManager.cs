using UnityEngine;

// == スロットの管理クラス == //
public class SlotManager : MonoBehaviour
{

    private int[,] _slot;  //スロットの行列(二次元配列)
    void Start()
    {
        // 二次元配列では行列のデータを持つことができる。
        _slot = new int[,] //スロットの初期化
        {
            { 0,0,0 },
            { 1,1,1 },
            { 2,2,2 },
            { 3,3,3 },
            { 4,4,4 }
        };
    }

    
    void Update()
    {
        PlayingSlot();
    }

    // === スロット回転のメインメソッド === //
    // 全てのリールが1回ずつ回っている？
    public void PlayingSlot()
    {
        int reelLength = _slot.GetLength(1);

        for (int x = 0; x < reelLength; x++)
        {
            ReelLoop(x);
        }
    }    
    // == スロットリールのループの管理 ==
    //※配列の中身を入れ替えてループを再現する
    //引数1：回転させるリール番号(int型)
    //戻り値：ない(void)
    public void ReelLoop(int reelIndex)
    {
        int length = _slot.GetLength(0);   //配列の行数を取得
        int temp = _slot[length - 1, reelIndex]; //最後の行の値を一時的に保存

        // １．int型のyを宣言します。
        // ２．(行数-1)をyに代入します。
        // ３．(y > 0) --- yがoより大きいなら繰り返す
        // ４．yから1減らしながら繰り返します。テクリメントという。
        for (int y = length - 1; y > 0; y--)
        {
            //スロット行列の[y番目、リール番目]に、
            //スロット行列の[y - 1番目,　リール番目]の値を代入する。
            _slot[y, reelIndex] = _slot[y - 1, reelIndex];
        }
        
        //保存しておいた最後の値を、
        //配列の最初の[0番目]に代入する
        _slot[0, reelIndex] = temp;
        
        Debug.Log($"_slot[0,{reelIndex}] = {_slot[0,reelIndex]}");
    }
}