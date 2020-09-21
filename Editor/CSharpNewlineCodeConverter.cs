using System.IO;
using System.Linq;
using UnityEditor;

namespace Kogane.Internal
{
	/// <summary>
	/// C# スクリプトのインポート時に改行コードを Unix から Win に変換するエディタ拡張 
	/// </summary>
	internal sealed class CSharpNewlineCodeConverter : AssetPostprocessor
	{
		//================================================================================
		// 定数
		//================================================================================
		private const string WINDOWS = "\r\n";
		private const string UNIX    = "\n";
		private const string MAC     = "\r";

		//================================================================================
		// 関数（static）
		//================================================================================
#if UNITY_EDITOR_WIN
		/// <summary>
		/// アセットがインポートされた時に呼び出されます
		/// </summary>
		private static void OnPostprocessAllAssets
		(
			string[] importedAssets,
			string[] deletedAssets,
			string[] movedAssets,
			string[] movedFromAssetPaths
		)
		{
			var list = importedAssets
					.Where( x => x.StartsWith( "Assets/" ) && x.EndsWith( ".cs" ) )
					.ToArray()
				;

			if ( list.Length <= 0 ) return;

			for ( var i = 0; i < list.Length; i++ )
			{
				var path    = list[ i ];
				var oldText = File.ReadAllText( path );
				var newText = oldText;

				// 一度 Win -> Unix に変換しないと改行コードの変換が成功しなかった
				newText = newText.Replace( WINDOWS, UNIX );

				newText = newText.Replace( MAC, UNIX );
				newText = newText.Replace( UNIX, WINDOWS );

				// 処理時間削減のため、
				// 改行コードの変換が不要であればファイルの書き込みは行わない
				if ( newText == oldText ) continue;

				File.WriteAllText( path, newText );
			}
		}
#endif
	}
}