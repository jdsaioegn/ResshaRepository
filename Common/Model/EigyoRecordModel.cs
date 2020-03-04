using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResshaDataBaseTools.Common.Model
{
    /// =======================================================================
    /// クラス名 ： EigyoRecordModel
    /// <summary>
    /// 列車営業レコードのマッピングを行うためのオブジェクトクラス
    /// </summary>
    /// <history>
    /// =======================================================================
    /// 更新履歴
    /// 項番　　　更新日付　　担当者　　更新内容
    /// 0001　　　2020/03/01  鶴　見    新規作成     
    /// =======================================================================
    /// </history>
    internal class EigyoRecordModel
    {
        /// <summary>列車番号</summary>
        public string ResshaNo { get; set; }

        /// <summary>使用編成区分</summary>
        public int HenseiKbn { get; set; }

        /// <summary>変更開始駅</summary>
        public string HenkoFromEkiCd { get; set; }

        /// <summary>営業種別コード</summary>
        public string EigyoShubetsuCd { get; set; }
    }
}
