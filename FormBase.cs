using ResshaDataBaseTools.Common;

namespace ResshaDataBaseTools
{
    /// <summary>
    /// フォームベースクラス
    /// </summary>
    public class FormBase : System.Windows.Forms.Form
    {
        /// <summary>
        /// トレースロガー
        /// </summary>
        protected readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// DB接続管理クラス
        /// </summary>
        protected DbContext _DbContext = new DbContext();
    }
}
