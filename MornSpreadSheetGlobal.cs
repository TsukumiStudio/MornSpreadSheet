using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("MornSpreadSheet.Editor")]
namespace MornLib
{
    internal sealed class MornSpreadSheetGlobal : MornGlobalPureBase<MornSpreadSheetGlobal>
    {
        protected override string ModuleName => "MornSpreadSheet";
    }
}