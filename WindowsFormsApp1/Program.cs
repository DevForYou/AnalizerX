using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using ZedGraph;

namespace WindowsFormsApp1{
    static class Program {
        /// Главная точка входа для приложения
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Парсинг данных из файла
            //var arrCot = Parser();
            //var x = Mapping(arrCot);
            //InsertToBase(arrCot);
        }

        //Добавить загрузку котировок со всей папки
        static string[,] Parser() {
            //Массив котировок
            int i = 0;
            char splitchar = ' ';
            string[,] arrCot = new string[300000, 4];
            string[] strArr = null;
            // Парсим CSV файл в массив
            using (Microsoft.VisualBasic.FileIO.TextFieldParser parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(@"C:\Users\P.mihalchenko\source\repos\WindowsFormsApp1\CSV\SPFB.RTS_180625_180626.csv")) {
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        //Загоняем данные из файла CSV в массив
                        splitchar = ';';
                        strArr = field.Split(splitchar);
                        for (int j = 0; j <= 3; j++)
                        {
                            arrCot[i, j] = strArr[j];
                        }
                        i++;
                    }
                }
            }
            return arrCot;
        }

        static string[,] Mapping(string[,] arrCot)
        {
            // Маппим данные в данных
            for (int i = 1; arrCot[i, 1] != null; i++)
            {
                arrCot[i, 0] = arrCot[i, 0].Substring(0, 4) + "-" + arrCot[i, 0].Substring(4, 2) + "-" + arrCot[i, 0].Substring(6, 2);
                arrCot[i, 0] += " " + arrCot[i, 1].Substring(0, 2) + ":" + arrCot[i, 1].Substring(2, 2) + ":" + arrCot[i, 1].Substring(4, 2);
                arrCot[i, 2] = Convert.ToString(Convert.ToInt32(arrCot[i, 2].Substring(0, arrCot[i, 2].IndexOf("."))));
            }
            return arrCot;
        }

        static void InsertToBase(string[,] InsertArr)
        {
            // Подключение к базе данных #Working
            System.Data.SqlClient.SqlConnection con;
            string sqlCon = @"Data Source=(localdb)\MSSQLLocalDB;" +
            @"AttachDbFilename=|DataDirectory|\Database1.mdf;
                Integrated Security=True;
                Connect Timeout=10";
            con = new System.Data.SqlClient.SqlConnection(sqlCon);
            con.Open();

            // Запросы к Базе данных
            for (int i = 1; InsertArr[i, 1] != null; i++)
            {
                string query = "INSERT INTO [dbo].[MAIN]([FULL_TIME], [LASTNUM], [VOL]) " +
                "VALUES (" + "'" + InsertArr[i, 0] + "'," + InsertArr[i, 2] + ", " + InsertArr[i, 3] + ");";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }

    }  
}
