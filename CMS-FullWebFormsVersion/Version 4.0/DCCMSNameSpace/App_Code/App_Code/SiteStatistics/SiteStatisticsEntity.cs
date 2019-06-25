using System;
using System.Collections.Generic;

using System.Web;
namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for SiteStatisticsEntity
    /// </summary>
    public class SiteStatisticsEntity
    {
        #region --------------StatisticID--------------
        private int _StatisticID;
        public int StatisticID
        {
            get { return _StatisticID; }
            set { _StatisticID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ModuleTypeID--------------
        private int _ModuleTypeID;
        public int ModuleTypeID
        {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------OwnerID--------------
        private Guid _OwnerID = Guid.Empty;
        public Guid OwnerID
        {
            get { return _OwnerID; }
            set { _OwnerID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AlltemsCount--------------
        private int _AlltemsCount;
        public int AlltemsCount
        {
            get { return _AlltemsCount; }
            set { _AlltemsCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AvailabletemsCount--------------
        private int _AvailabletemsCount;
        public int AvailabletemsCount
        {
            get { return _AvailabletemsCount; }
            set { _AvailabletemsCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------LastItemID--------------
        private int _LastItemID;
        public int LastItemID
        {
            get { return _LastItemID; }
            set { _LastItemID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------LastItemDate--------------
        private DateTime _LastItemDate = DateTime.MinValue;
        public DateTime LastItemDate
        {
            get { return _LastItemDate; }
            set { _LastItemDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AllVisitorsParticipationsCount--------------
        private int _AllVisitorsParticipationsCount;
        public int AllVisitorsParticipationsCount
        {
            get { return _AllVisitorsParticipationsCount; }
            set { _AllVisitorsParticipationsCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AvailableVisitorsParticipationsCount--------------
        private int _AvailableVisitorsParticipationsCount;
        public int AvailableVisitorsParticipationsCount
        {
            get { return _AvailableVisitorsParticipationsCount; }
            set { _AvailableVisitorsParticipationsCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------NewVisitorsParticipationsCount--------------
        private int _NewVisitorsParticipationsCount;
        public int NewVisitorsParticipationsCount
        {
            get { return _NewVisitorsParticipationsCount; }
            set { _NewVisitorsParticipationsCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AllMessagesCount--------------
        private int _AllMessagesCount;
        public int AllMessagesCount
        {
            get { return _AllMessagesCount; }
            set { _AllMessagesCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------NewMessagesCount--------------
        private int _NewMessagesCount;
        public int NewMessagesCount
        {
            get { return _NewMessagesCount; }
            set { _NewMessagesCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AvailableMessagesCount--------------
        private int _AvailableMessagesCount;
        public int AvailableMessagesCount
        {
            get { return _AvailableMessagesCount; }
            set { _AvailableMessagesCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------LastMessageID--------------
        private int _LastMessageID;
        public int LastMessageID
        {
            get { return _LastMessageID; }
            set { _LastMessageID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------LastMessageDate--------------
        private DateTime _LastMessageDate = DateTime.MinValue;
        public DateTime LastMessageDate
        {
            get { return _LastMessageDate; }
            set { _LastMessageDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AllCommentsCount--------------
        private int _AllCommentsCount;
        public int AllCommentsCount
        {
            get { return _AllCommentsCount; }
            set { _AllCommentsCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AvailableCommentsCount--------------
        private int _AvailableCommentsCount;
        public int AvailableCommentsCount
        {
            get { return _AvailableCommentsCount; }
            set { _AvailableCommentsCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------LastCommentDate--------------
        private DateTime _LastCommentDate = DateTime.MinValue;
        public DateTime LastCommentDate
        {
            get { return _LastCommentDate; }
            set { _LastCommentDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AllCategoriesCount--------------
        private int _AllCategoriesCount;
        public int AllCategoriesCount
        {
            get { return _AllCategoriesCount; }
            set { _AllCategoriesCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AvailableCategoriesCount--------------
        private int _AvailableCategoriesCount;
        public int AvailableCategoriesCount
        {
            get { return _AvailableCategoriesCount; }
            set { _AvailableCategoriesCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------LastCategoryID--------------
        private int _LastCategoryID;
        public int LastCategoryID
        {
            get { return _LastCategoryID; }
            set { _LastCategoryID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------LastCategoryDate--------------
        private DateTime _LastCategoryDate = DateTime.MinValue;
        public DateTime LastCategoryDate
        {
            get { return _LastCategoryDate; }
            set { _LastCategoryDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AllUsersCount--------------
        private int _AllUsersCount;
        public int AllUsersCount
        {
            get { return _AllUsersCount; }
            set { _AllUsersCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ActiveUsersCount--------------
        private int _ActiveUsersCount;
        public int ActiveUsersCount
        {
            get { return _ActiveUsersCount; }
            set { _ActiveUsersCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------LastUserDate--------------
        private DateTime _LastUserDate = DateTime.MinValue;
        public DateTime LastUserDate
        {
            get { return _LastUserDate; }
            set { _LastUserDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------LastUserId--------------
        private Guid _LastUserId = Guid.Empty;
        public Guid LastUserId
        {
            get { return _LastUserId; }
            set { _LastUserId = value; }
        }
        //------------------------------------------
        #endregion

        public SiteStatisticsEntity()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}