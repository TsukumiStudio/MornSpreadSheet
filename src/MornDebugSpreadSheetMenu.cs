using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MornLib
{
    /// <summary>
    /// MornSpreadSheetMaster を MornDebug メニューから操作する ScriptableObject。
    /// メニュー内に「シートを開く」「シートを更新（シート名取得 → ダウンロード）」のボタンを描画する。
    /// </summary>
    [CreateAssetMenu(
        fileName = nameof(MornDebugSpreadSheetMenu),
        menuName = "Morn/Debug/" + nameof(MornDebugSpreadSheetMenu))]
    public sealed class MornDebugSpreadSheetMenu : MornDebugMenuBase
    {
        [SerializeField] private string _menuKey = "SpreadSheet";
        [SerializeField] private MornSpreadSheetMaster _master;

        public override IEnumerable<(string key, Action action)> GetMenuItems()
        {
            yield return (_menuKey, () =>
            {
                if (_master == null)
                {
                    GUILayout.Label("MornSpreadSheetMaster 未設定");
                    return;
                }

                if (GUILayout.Button("シートを開く"))
                {
                    _master.Open();
                }

                if (GUILayout.Button("シートを更新"))
                {
                    UpdateAsync().Forget();
                }
            });
        }

        private async UniTaskVoid UpdateAsync()
        {
            await _master.UpdateSheetNamesWithProgressAsync();
            await _master.DownloadSheetsWithProgressAsync();
        }
    }
}
