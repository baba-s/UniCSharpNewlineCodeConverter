# UniCSharpNewlineCodeConverter

C# スクリプトの改行コードを Win に統一するエディタ拡張

## 概要

```
There are inconsistent line endings in the 'XXXX.cs' script. 
Some are Mac OS X (UNIX) and some are Windows.
This might lead to incorrect line numbers in stacktraces and compiler errors. 
Many text editors can fix this using Convert Line Endings menu commands.
```

C# スクリプトの改行コードに Win と Unix が混在していると  
Unity の Console に上記の警告ログが出力されます  

UniCSharpNewlineCodeConverter を Unity プロジェクトに導入することで  
C# スクリプトのインポート時に改行コードが Win で統一されるようになり、  
上記の警告ログが出力されなくなります  
