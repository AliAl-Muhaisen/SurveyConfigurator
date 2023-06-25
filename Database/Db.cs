using SurveyConfiguratorApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Database
{

    public interface ICRUD<T>
    {
        bool create(T data);
        bool update(T data);
        bool delete(int id);
        T read(int id);
    }

    /// <summary>
    /// The DB class provides functionality for managing database connections 
    /// using ADO.NET. It includes methods to open and close the database connection.
    /// </summary>
    public class DB
    {
        public SqlConnection conn;
        //protected SqlCommand cmd;
        private string connectionString;

        private static bool isTablesCreated = false;
        public DB()
        {


            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                conn = new SqlConnection(connectionString);
                OpenConnection();


                if (!isTablesCreated)
                {
                    createTables();
                    isTablesCreated = true;
                }
            }
            catch (Exception ex)
            {
                isTablesCreated = false;
                handleExceptionLog(ex);


            }
            finally
            {
                CloseConnection();
            }
        }

        // Open the database connection
        public void OpenConnection()
        {
            try
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                conn = new SqlConnection(connectionString);
                //cmd = conn.CreateCommand();
                conn.Open();
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }
        }

        // Close the database connection
        public void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn = null;
            }
        }
        protected void handleExceptionLog(Exception ex)
        {
            try
            {
                ErrorLoggerFile errorLoggerFile = new ErrorLoggerFile();
                errorLoggerFile.HandleException(ex);
            }
            catch { }
        }

        //Create table by pass the Create Query
        private void createTable(string query)
        {
            try
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                handleExceptionLog(e);
            }
        }

        // Create db tables
        private void createTables()
        {
            try
            {
                createQuestioTable();
                createQuestionFacesTable();
                createQuestioSliderTable();
                createQuestioStarsTable();
            }
            catch (Exception e)
            {
                handleExceptionLog(e);
            }
        }
        private void createQuestioTable()
        {
            try
            {
                createTable(@"
                            IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Question]') AND type in (N'U'))
                            BEGIN
                            CREATE TABLE [dbo].[Question] (
                                [Id]         INT           IDENTITY (1, 1) NOT NULL,
                                [Order]      INT           NOT NULL,
                                [Text]       VARCHAR (100) NOT NULL,
                                [TypeNumber] INT           NOT NULL,
                                PRIMARY KEY CLUSTERED ([Id] ASC),
                                CONSTRAINT [unique_order] UNIQUE NONCLUSTERED ([Order] ASC)
                            );
                            END");
            }
            catch (Exception e)
            {
                handleExceptionLog(e);
            }
        }
        private void createQuestionFacesTable()
        {
            try
            {
                createTable(@"
                            IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QuestionFaces]') AND type in (N'U'))
                            BEGIN
                           CREATE TABLE [dbo].[QuestionFaces] (
                            [Id]          INT IDENTITY (1, 1) NOT NULL,
                            [FacesNumber] INT NOT NULL,
                            [QuestionId]  INT NOT NULL,
                            PRIMARY KEY CLUSTERED ([Id] ASC),
                            CONSTRAINT [FK_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id]) ON DELETE CASCADE,
                            CONSTRAINT [Check_Faces_Number] CHECK ([FacesNumber] >= (0)
                                                                       AND [FacesNumber] <= (10))
                        );
                            END");
            }
            catch (Exception e)
            {
                handleExceptionLog(e);
            }
        }
        private void createQuestioSliderTable()
        {
            try
            {
                createTable(@"
                            IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QuestionSlider]') AND type in (N'U'))
                            BEGIN
                            CREATE TABLE [dbo].[QuestionSlider] (
                            [Id]           INT           IDENTITY (1, 1) NOT NULL,
                            [StartValue]   INT           NOT NULL,
                            [EndValue]     INT           NOT NULL,
                            [StartCaption] VARCHAR (100) NOT NULL,
                            [EndCaption]   VARCHAR (100) NOT NULL,
                            [QuestionId]   INT           NOT NULL,
                            PRIMARY KEY CLUSTERED ([Id] ASC),
                            CONSTRAINT [FK_QuestionId_Slider] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id]) ON DELETE CASCADE,
                            CONSTRAINT [Check_Slider_EndValue] CHECK ([EndValue] >= [StartValue]
                                                                          AND [EndValue] <= (100)),
                            CONSTRAINT [Check_Slider_StartValue] CHECK ([StartValue] >= (0)
                                                                            AND [StartValue] < [EndValue])
                        );

                            END");
            }
            catch (Exception e)
            {
                handleExceptionLog(e);
            }
        }
        private void createQuestioStarsTable()
        {
            try
            {
                createTable(@"
                            IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QuestionStars]') AND type in (N'U'))
                            BEGIN
                            CREATE TABLE [dbo].[QuestionStars] (
                                [Id]          INT IDENTITY (1, 1) NOT NULL,
                                [StarsNumber] INT NOT NULL,
                                [QuestionId]  INT NOT NULL,
                                PRIMARY KEY CLUSTERED ([Id] ASC),
                                CONSTRAINT [FK_QuestionId_Stars] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id]) ON DELETE CASCADE,
                                CONSTRAINT [Check_Stars_Number] CHECK ([StarsNumber] >= (1)
                                                                           AND [StarsNumber] <= (10))
                            );
                            END");
            }
            catch (Exception e)
            {
                handleExceptionLog(e);
            }
        }

    }
}
