# MornSpreadSheet

## 概要

Googleスプレッドシートのダウンロードとデータ管理を行うライブラリ。

## 依存関係

| 種別 | 名前 |
|------|------|
| 外部パッケージ | UniTask |
| Mornライブラリ | MornGlobal |

## 使い方

### セットアップ

1. Projectウィンドウで右クリック → `Morn/MornSpreadSheetMaster` を作成
2. `SheetId` にスプレッドシートのIDを設定
3. `SheetNames` にダウンロードしたいシート名を追加
4. InspectorのDownloadボタンでシートをダウンロード

### シートのダウンロード（エディタ専用）

```csharp
await master.DownloadSheetsWithProgressAsync();
var sheet = await MornSpreadSheetDownloader.LoadSheetAsync(sheetId, sheetName);
```

### セルの取得

```csharp
// 行と列を指定（1始まり）
MornSpreadSheetCell cell = sheet.Get(rowIdx: 1, colIdx: 1);
MornSpreadSheetRow row = sheet.GetRow(1);
```

### セルの値変換

```csharp
cell.AsString();
cell.AsInt();
cell.AsFloat();
cell.AsBool();
```

### CSV解析仕様

- RFC 4180準拠のCSV解析
- `#` で始まる行/列はコメントとして無視
- 空白行は自動スキップ
