using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResshaDataBaseTools.Common.Model
{
    /// =======================================================================
    /// クラス名 ： UnyoRecordModel
    /// <summary>
    /// 列車運用レコードのマッピングを行うためのオブジェクトクラス
    /// </summary>
    /// <history>
    /// =======================================================================
    /// 更新履歴
    /// 項番　　　更新日付　　担当者　　更新内容
    /// 0001　　　2020/03/01  鶴　見    新規作成     
    /// =======================================================================
    /// </history>
    internal class UnyoRecordModel
    {
        /// <summary>施工日</summary>
        public int SekoDate { get; set; }

        /// <summary>車両運用番号</summary>
        public int SharyoUnyoNo { get; set; }

        /// <summary>列車施工日</summary>
        public int ResshaSekoDate { get; set; }

        /// <summary>列車番号</summary>
        public string ResshaNo { get; set; }

        /// <summary>編成区分</summary>
        public int HenseiKbn { get; set; }

        /// <summary>足列車順序</summary>
        public int AshiResshaJunjo { get; set; }
    }
}
