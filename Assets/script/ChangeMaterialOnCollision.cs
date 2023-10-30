using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialOnCollision : MonoBehaviour
{
    public Material newMaterial; // 新しいマテリアルをアサインするための変数

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトのタグが特定のものである場合にマテリアルを変更
        if (collision.gameObject.CompareTag("YourTagHere"))
        {
            Renderer objectRenderer = GetComponent<Renderer>();

            // マテリアルの変更
            if (objectRenderer != null && newMaterial != null)
            {
                objectRenderer.material = newMaterial;
            }
        }
    }
}
