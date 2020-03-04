using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResshaDataBaseTools.Common.Model
{
    /// =======================================================================
    /// クラス名 ： AllUpdateModel
    /// <summary>
    /// 実績更新機能（一括更新）実施時に使用するオブジェクトクラス
    /// </summary>
    /// <history>
    /// =======================================================================
    /// 更新履歴
    /// 項番　　　更新日付　　担当者　　更新内容
    /// 0001　　　2020/03/01  鶴　見    新規作成     
    /// =======================================================================
    /// </history>
    public class AllUpdateModel
    {
        /// <summary>列車番号</summary>
        public string ResshaNo { get; set; }

        /// <summary>駅コード</summary>
        public string EkiCd { get; set; }

        /// <summary>走行順序</summary>
        public int SokoJunjo { get; set; }

        /// <summary>実施時刻</summary>
        public int JisshiTime { get; set; }

        /// <summary>実績時刻</summary>
        public int JissekiTime { get; set; }

        /// <summary>着発フラグ</summary>
        public bool ChakuHatsu { get; set; }
    }
}
