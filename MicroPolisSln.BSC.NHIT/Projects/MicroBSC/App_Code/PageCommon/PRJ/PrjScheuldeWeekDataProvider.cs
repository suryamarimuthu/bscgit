using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Xml;
using System.Xml.XPath;
using System.Data;
using Infragistics.WebUI.Data;
using Infragistics.WebUI.WebSchedule;
using Infragistics.WebUI.Shared;

namespace MicroBSC.Common
{
    /// <summary>
    /// Summary description for PrjScheuldeDataProvider
    /// </summary>
    public class PrjScheuldeWeekDataProvider : WebScheduleDataProviderBase, IDataFetch, IDataUpdate
    {
        private DataTable _dataSchedule = null;

        public PrjScheuldeWeekDataProvider()
        {
        }

        public PrjScheuldeWeekDataProvider(DataTable dt)
        {
            _dataSchedule = dt;
        }

        /// <summary>
        /// Fetches WebSchedule objects from the underlying data source.
        /// </summary>
        /// <param name="context">A <see cref="DataContext"/> subclass containing parameter values for
        /// use when carrying out a fetch operation.</param>
        public void Fetch(DataContext context)
        {
            // Take action based on the operation provided
            switch (context.Operation)
            {
                case "FetchActivities":
                    FetchActivities((FetchActivitiesContext)context);
                    break;
            }
        }

        /// <summary>
        /// Selects activities from the WebSchedule data store by date range and organizer.
        /// </summary>
        /// <param name="context">Describes the <see cref="Activities"/> being selected, in particular,
        /// their organizing resource and date range of interest.</param>
        private void FetchActivities(FetchActivitiesContext context)
        {
            //// Clear any existing activities
            context.Activities.Clear();


            foreach (DataRow row in _dataSchedule.Rows)
            {
                if (row["PLAN_START_DATE"] != DBNull.Value && row["PLAN_END_DATE"] != DBNull.Value)
                {
                    if (row["UP_TASK_REF_ID"].ToString() != "0")
                    {
                        Appointment appointment = new Appointment(this.WebScheduleInfo);
                        appointment.Key = row["TASK_REF_ID"].ToString() + "|" + row["PRJ_REF_ID"].ToString();
                        appointment.Subject = row["TASK_CODE"].ToString() + " " + row["TASK_NAME"].ToString();
                        appointment.StartDateTime = StringToDate(row["PLAN_START_DATE"].ToString());


                        //appointment.EndDateTime = StringToDate(row["PLAN_START_DATE"].ToString());
                        appointment.EndDateTime = StringToDate(row["PLAN_END_DATE"].ToString()).AddDays(1);

                        appointment.Description = StringToDate(row["PLAN_START_DATE"].ToString()).ToShortDateString() + " ~ " + StringToDate(row["PLAN_END_DATE"].ToString()).ToShortDateString();

                        ((IList)context.Activities).Add(appointment);
                    }
                }
            }
        }

        /// <summary>
        /// Invokes an update operation on the data source.  The type of operation is determined by the
        /// DataContext that is passed.
        /// </summary>
        /// <param name="context">A <see cref="DataContext"/> subclass containing parameter values for
        /// use when carrying out an update operation.</param>
        public void Update(DataContext context)
        {
            
        }

        /// <summary>
        /// Adds an activity to the WebSchedule data store.
        /// </summary>
        /// <param name="context">Describes the <see cref="Activity"/> being added.</param>
        private void AddActivity(AddActivityContext context)
        {
           
        }

        /// <summary>
        /// Removes an activity from the WebSchedule data store.
        /// </summary>
        /// <param name="context">Describes the <see cref="Activity"/> being removed.</param>
        private void RemoveActivity(RemoveActivityContext context)
        {
            
        }

        /// <summary>
        /// Updates an existing activity in the WebSchedule data store.
        /// </summary>
        /// <param name="context">Describes the <see cref="Activity"/> being updated, in particular, the
        /// data key uniquely identifying this Activity.</param>
        private void UpdateActivity(UpdateActivityContext context)
        {
           
        }

        #region Helper methods
        /// <summary>
        /// Creates a <see cref="SmartDate"/> object from the provided <see cref="string"/>.
        /// </summary>
        /// <param name="dateString">The string to convert.</param>
        /// <returns>The <see cref="SmartDate"/> described by <i>dateString</i></returns>
        private SmartDate StringToDate(string dateString)
        {
            return new SmartDate(DateTime.Parse(dateString));
        }

        

        #endregion
    }
}