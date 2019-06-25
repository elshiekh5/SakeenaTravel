using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;


namespace DCCMSNameSpace
{
    public class VoteQuestionsSqlDataPrvider
    {
        #region --------------Instance--------------
        private static VoteQuestionsSqlDataPrvider _Instance;
        public static VoteQuestionsSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new VoteQuestionsSqlDataPrvider();
                }
                return _Instance;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetSqlConnection--------------
        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ToString());
        }
        //------------------------------------------
        #endregion

        #region --------------Save--------------
        public bool Save(VoteQuestionsEntity voteQuestions, SPOperation operation)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("VoteQuestions_Save", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@SPOperation", SqlDbType.Int, 4).Value = (int)operation;
                if (operation == SPOperation.Insert)
                    myCommand.Parameters.Add("@QuesID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                else
                    myCommand.Parameters.Add("@QuesID", SqlDbType.Int, 4).Value = voteQuestions.QuesID;

                myCommand.Parameters.Add("@QuestionText", SqlDbType.NVarChar, 128).Value = voteQuestions.QuestionText;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int).Value = (int)voteQuestions.LangID;
                myCommand.Parameters.Add("@AnswersCount", SqlDbType.Int, 4).Value = voteQuestions.AnswersCount;
                myCommand.Parameters.Add("@IsMain", SqlDbType.Bit, 1).Value = voteQuestions.IsMain;
                myCommand.Parameters.Add("@IsClosed", SqlDbType.Bit, 1).Value = voteQuestions.IsClosed;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                // Execute the command
                bool status = false;
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    status = true;
                    //Get ID value from database and set it in object
                    voteQuestions.QuesID = (int)myCommand.Parameters["@QuesID"].Value;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion


        #region --------------Open--------------
        public bool Open(int quesID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("VoteQuestions_Open", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@QuesID", SqlDbType.Int, 4).Value = quesID;
                // Execute the command
                bool status = false;
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    status = true;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Close--------------
        public bool Close(int quesID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("VoteQuestions_Close", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@QuesID", SqlDbType.Int, 4).Value = quesID;
                // Execute the command
                bool status = false;
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    status = true;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single VoteQuestions object .
        /// <example>[Example]bool status=VoteQuestionsSqlDataPrvider.Instance.Delete(quesID);.</example>
        /// </summary>
        /// <param name="quesID">The voteQuestions id.</param>
        /// <returns>The status of delete query.</returns>
        public bool Delete(int quesID)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("VoteQuestions_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@QuesID", SqlDbType.Int, 4).Value = quesID;
                // Execute the command
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    status = true;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public List<VoteQuestionsEntity> GetAll(bool olnyPreviousVotes, Languages langID, int pageIndex, int pageSize, out int totalRecords)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<VoteQuestionsEntity> voteQuestionsList = new List<VoteQuestionsEntity>();
                VoteQuestionsEntity voteQuestions;
                SqlCommand myCommand = new SqlCommand("VoteQuestions_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@PreviousVotes", SqlDbType.Bit, 1).Value = olnyPreviousVotes;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 8).Value = (int)langID;
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    (voteQuestions) = PopulateEntity(dr);
                    voteQuestionsList.Add(voteQuestions);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                return voteQuestionsList;
            }
        }
        #endregion

        #region --------------GetObject--------------
        public VoteQuestionsEntity GetObject(int quesID)
        {
            VoteQuestionsEntity voteQuestions = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("VoteQuestions_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@QuesID", SqlDbType.Int, 4).Value = quesID;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        voteQuestions = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return voteQuestions;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetMain--------------
        public VoteQuestionsEntity GetMain(Languages langID)
        {
            VoteQuestionsEntity voteQuestions = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("VoteQuestions_GetMain", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        voteQuestions = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return voteQuestions;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------PopulateEntity--------------
        private VoteQuestionsEntity PopulateEntity(IDataReader reader)
        {
            //Create a new VoteQuestions object
            VoteQuestionsEntity voteQuestions = new VoteQuestionsEntity();
            //Fill the object with data
            //QuesID
            if (reader["QuesID"] != DBNull.Value)
                voteQuestions.QuesID = (int)reader["QuesID"];
            //QuestionText
            if (reader["QuestionText"] != DBNull.Value)
                voteQuestions.QuestionText = (string)reader["QuestionText"];
            //LangID
            if (reader["LangID"] != DBNull.Value)
                voteQuestions.LangID = (Languages)reader["LangID"];
            //CreatedOn
            if (reader["CreatedOn"] != DBNull.Value)
                voteQuestions.CreatedOn = (DateTime)reader["CreatedOn"];
            //IsClosed
            if (reader["IsClosed"] != DBNull.Value)
                voteQuestions.IsClosed = (bool)reader["IsClosed"];
            //AnswersCount
            if (reader["AnswersCount"] != DBNull.Value)
                voteQuestions.AnswersCount = (int)reader["AnswersCount"];
            //IsMain
            if (reader["IsMain"] != DBNull.Value)
                voteQuestions.IsMain = (bool)reader["IsMain"];
            //TotalHits
            if (reader["TotalHits"] != DBNull.Value)
                voteQuestions.TotalHits = (int)reader["TotalHits"];
            //Return the populated object
            return voteQuestions;
        }
        //------------------------------------------
        #endregion
    }

}