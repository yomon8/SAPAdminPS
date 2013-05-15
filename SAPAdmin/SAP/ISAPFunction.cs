using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPAdminPS.SAP
{
    public interface ISAPFunction
    {
        /// <summary>
        /// SAP連携機能の実行
        /// </summary>
        /// <returns>SAPリターン構造</returns>
        SapReturn Execute();
    }
}
