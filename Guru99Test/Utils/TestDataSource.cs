using System.Collections;
using System.Data;
using NUnit.Framework;

namespace Guru99Test.Utils
{
    public class TestDataSource
    {
        public static IEnumerable GetData()
        {
            yield return new TestCaseData("mngr444957", "YgypEpU");
            yield return new TestCaseData("mngr444957", "YgypEpU");
        }

        public static IEnumerable GetDataFromDatabase()
        {
            DatabaseUtils databaseUtils = new DatabaseUtils("localhost", "Guru99TestData", "root", "admin@1234");
            databaseUtils.OpenConnection();

            string sqlQuery = "select * from users";

            DataTable testData = databaseUtils.ExecuteSelectSqlQuery(sqlQuery);

            databaseUtils.CloseConnection();

            foreach (DataRow row in testData.Rows)
            {
                yield return new TestCaseData(row.ItemArray);
            }
        }
    }
}