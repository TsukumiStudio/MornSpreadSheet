# MornSpreadSheet

Googleスプレッドシートのダウンロードとデータ管理を行うライブラリ

## 依存関係

- UniTask
- MornGlobal

## セットアップ

1. `Project`を右クリック → `Morn/MornSpreadSheetMaster`を作成
2. `SheetId`にスプレッドシートのIDを設定（URLの`/d/`と`/edit`の間の文字列）
3. `SheetNames`にダウンロードしたいシート名を追加
4. InspectorのDownloadボタンでシートをダウンロード

## 使い方

### シートのダウンロード（エディタ専用）

```csharp
// MornSpreadSheetMasterからダウンロード（プログレスバー付き）
await master.DownloadSheetsWithProgressAsync();

// 単一シートのダウンロード
var sheet = await MornSpreadSheetDownloader.LoadSheetAsync(sheetId, sheetName);
```

### セルの取得

```csharp
// 行と列を指定してセルを取得（1始まり）
MornSpreadSheetCell cell = sheet.Get(rowIdx: 1, colIdx: 1);

// 行を取得
MornSpreadSheetRow row = sheet.GetRow(1);

// 行内のセルを取得
MornSpreadSheetCell cell = row.GetCell(colIdx: 1);
```

### セルの値変換

```csharp
cell.AsString(); // 文字列として取得
cell.AsInt();    // 整数として取得
cell.AsFloat();  // 浮動小数点数として取得
cell.AsBool();   // 真偽値として取得
```

### シートの列挙

```csharp
// 全シートを列挙
foreach (var sheet in master.Sheets)
{
    Debug.Log(sheet.SheetName);
}

// シート内の全行を列挙
foreach (var row in sheet.GetRows())
{
    Debug.Log(row.AsString());
}
```

### その他

```csharp
// スプレッドシートをブラウザで開く
master.Open();

// シート名をAPIから取得（GetSheetNameApiUrl設定時）
await master.UpdateSheetNamesWithProgressAsync();
```

## 主要クラス

| クラス | 機能 |
|---|---|
| `MornSpreadSheetMaster` | シートID・シート名・ダウンロード済みシートを管理するScriptableObject |
| `MornSpreadSheetDownloader` | エディタ専用のダウンロード機能 |
| `MornSpreadSheet` | シートデータ（行と列のコレクション） |
| `MornSpreadSheetRow` | 行データ（セルのコレクション） |
| `MornSpreadSheetCell` | セルデータ（値の取得と型変換） |

## CSV解析仕様

- RFC 4180準拠のCSV解析
- ダブルクォーテーションで囲まれたフィールド内の改行・カンマに対応
- 1行目/1列目が`#`で始まる場合はコメントとして無視
- 空白行は自動的にスキップ
