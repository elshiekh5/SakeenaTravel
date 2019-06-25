using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;


namespace DCCMSNameSpace
{
    public class VoteAnswersSqlDataPrvider
    {

        #region --------------Instance--------------
        private static VoteAnswersSqlDataPrvider _Instance;
        public static VoteAnswersSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new VoteAnswersSqlDataPrvider();
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

        #region --------------Create--------------
        /// <summary>
        /// Converts the VoteAnswers object properties to SQL paramters and executes the create VoteAnswers procedure 
        /// and updates the VoteAnswers object with the SQL data by reference.
        /// <example>[Example]bool status=VoteAnswersSqlDataPrvider.Instance.Create(voteAnswers);.</example>
        /// </summary>
        /// <param name="voteAnswers">The VoteAnswers object.</param>
        /// <returns>The status of create query.</returns>
        public bool Create(VoteAnswersEntity voteAnswers)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("VoteAnswers_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@AnswerId", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@QuesID", SqlDbType.Int, 4).Value = voteAnswers.QuesID;
                myCommand.Parameters.Add("@AnswerText", SqlDbType.NVarChar, 128).Value = voteAnswers.AnswerText;
                // Execute the command
                bool status = false;
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    status = true;
                    //Get ID value from database and set it in object
                    voteAnswers.AnswerId = (int)myCommand.Parameters["@AnswerId"].Value;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        public bool Delete(int quesID)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("VoteAnswers_Delete", myConnection);
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

        #region --------------IncreaseHits--------------
        public bool IncreaseHits(int QuesID, int answerId)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("VoteAnswers_IncreaseHits", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@AnswerId", SqlDbType.Int, 4).Value = answerId;
                myCommand.Parameters.Add("@QuesID", SqlDbType.Int, 4).Value = QuesID;
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

        #region --------------GetQuesAnswers--------------
        public List<VoteAnswersEntity> GetQuesAnswers(int quesID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<VoteAnswersEntity> voteAnswersList = new List<VoteAnswersEntity>();
                VoteAnswersEntity voteAnswers;
                SqlCommand myCommand = new SqlCommand("VoteAnswers_GetQuesAnswers", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@QuesID", SqlDbType.Int, 4).Value = quesID;
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    (voteAnswers) = PopulateEntity(dr);
                    voteAnswersList.Add(voteAnswers);
                }
                dr.Close();
                myConnection.Close();
                return voteAnswersList;
            }
        }
        #endregion

        #region --------------PopulateEntity--------------
        private VoteAnswersEntity PopulateEntity(IDataReader reader)
        {
            //Create a new VoteAnswers object
            VoteAnswersEntity voteAnswers = new VoteAnswersEntity();
            //Fill the object with data
            //AnswerId
            if (reader["AnswerId"] != DBNull.Value)
                voteAnswers.AnswerId = (int)reader["AnswerId"];
            //QuesID
            if (reader["QuesID"] != DBNull.Value)
                voteAnswers.QuesID = (int)reader["QuesID"];
            //AnswerText
            if (reader["AnswerText"] != DBNull.Value)
                voteAnswers.AnswerText = (string)reader["AnswerText"];
            //HitsCount
            if (reader["HitsCount"] != DBNull.Value)
                voteAnswers.HitsCount = (int)reader["HitsCount"];
            //Return the populated object
            return voteAnswers;
        }
        //------------------------------------------
        #endregion
    }

}