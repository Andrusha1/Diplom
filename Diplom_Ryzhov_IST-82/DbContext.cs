using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Ryzhov_IST_82
{
    public class DbContext
    {
        
        
        public void DbConnect()
        {
            MainWindow mw = new MainWindow();
            String connectionString = "Host = localhost; Database = Diplomdb; Username = postgres; Password = admin;";
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
            //mw.isDbCheck.IsChecked = true;
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand("SELECT * FROM clientsstreets", npgSqlConnection);
            NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
            if (npgSqlDataReader.HasRows)
            {
                mw.TBOutput.AppendText("Таблица: clientsstreets\n");
                mw.TBOutput.AppendText("id\tStreet name\tHouse number\tSection or flat\tPayed this Month\n");
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    mw.TBOutput.AppendText(dbDataRecord["id"] + "\t" + dbDataRecord["streetname"] + "\t" + dbDataRecord["housenumber"] + "\t\t" + dbDataRecord["sectionorflat"] + "\t\t" + dbDataRecord["ispayed"]);
            }
            else
                mw.TBOutput.AppendText("Запрос не вернул строк");
        }

        public void DbDisconnect()
        {

        }
    }
}
