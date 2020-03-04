using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResshaDataBaseTools.Common.Model
{
    /// =======================================================================
    /// クラス名 ： MasterRecordModel
    /// <summary>
    /// マスタレコードのマッピングを行うためのオブジェクトクラス
    /// </summary>
    /// <history>
    /// =======================================================================
    /// 更新履歴
    /// 項番　　　更新日付　　担当者　　更新内容
    /// 0001　　　2020/03/01  鶴　見    新規作成     
    /// =======================================================================
    /// </history>
    internal class MasterRecordModel
    {
        /// <summary>種別コード</summary>
        public string ShubetsuCd { get; set; }

        /// <summary>名称コード</summary>
        public string MeishoCd { get; set; }

        /// <summary>3文字名称</summary>
        public string SanMojiMeisho { get; set; }
    }
}
