/* Title:           Audit Report Email List
 * Date:            8-20-18
 * Author:          Terry Holmes
 * 
 * Description:     This is the class that will bring up audit email list */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace AuditReportEmailListDLL
{
    public class AuditReportEmailListClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        AuditReportEmailListDataSet aAuditReportEmailListDataSet;
        AuditReportEmailListDataSetTableAdapters.auditreportemaillistTableAdapter aAuditReportEmailListTableAdapter;

        InsertAuditReportEmailListEmployeeEntryTableAdapters.QueriesTableAdapter aInsertAuditReportEmailListEmployeeTableAdapter;

        RemoveEmployeeFromAuditReportEntryTableAdapters.QueriesTableAdapter aRemoveEmployeeFromAuditReportTableAdapter;

        FindAuditReportEmployeeByEmployeeIDDataSet aFindAuditReportEmployeeByEmployeeIDDataSet;
        FindAuditReportEmployeeByEmployeeIDDataSetTableAdapters.FindAuditReportEmployeeByEmployeeIDTableAdapter aFindAuditReportEmployeeByEmployeeIDTableAdapter;

        FindSortedAuditEmailListDataSet aFindSortedAuditEmailListDataSet;
        FindSortedAuditEmailListDataSetTableAdapters.FindSortedAuditEmailListTableAdapter aFindSortedAuditEmailListTableAdapter;

        public FindSortedAuditEmailListDataSet FindSortedAuditEmailList()
        {
            try
            {
                aFindSortedAuditEmailListDataSet = new FindSortedAuditEmailListDataSet();
                aFindSortedAuditEmailListTableAdapter = new FindSortedAuditEmailListDataSetTableAdapters.FindSortedAuditEmailListTableAdapter();
                aFindSortedAuditEmailListTableAdapter.Fill(aFindSortedAuditEmailListDataSet.FindSortedAuditEmailList);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Audit Report Email List Class // Find Sorted Email List " + Ex.Message);
            }

            return aFindSortedAuditEmailListDataSet;
        }
        public FindAuditReportEmployeeByEmployeeIDDataSet FindAuditReportEmployeeByEmployeeID(int intEmployeeID)
        {
            try
            {
                aFindAuditReportEmployeeByEmployeeIDDataSet = new FindAuditReportEmployeeByEmployeeIDDataSet();
                aFindAuditReportEmployeeByEmployeeIDTableAdapter = new FindAuditReportEmployeeByEmployeeIDDataSetTableAdapters.FindAuditReportEmployeeByEmployeeIDTableAdapter();
                aFindAuditReportEmployeeByEmployeeIDTableAdapter.Fill(aFindAuditReportEmployeeByEmployeeIDDataSet.FindAuditReportEmployeeByEmployeeID, intEmployeeID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Audit Report Email list Class // Find Audit Report Employee By Employee ID " + Ex.Message);
            }

            return aFindAuditReportEmployeeByEmployeeIDDataSet;
        }
        public bool RemoveEmployeeFromAuditReport(int intEmployeeID)
        {
            bool blnFatalError = false;

            try
            {
                aRemoveEmployeeFromAuditReportTableAdapter = new RemoveEmployeeFromAuditReportEntryTableAdapters.QueriesTableAdapter();
                aRemoveEmployeeFromAuditReportTableAdapter.RemoveEmployeeFromAuditReport(intEmployeeID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Audit Report Email List Class // Remove Employee From Audit Report " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool InsertAuditReportEmailListEmployee(int intEmployeeID, string strEmailAddress)
        {
            bool blnFatalError = false;

            try
            {
                aInsertAuditReportEmailListEmployeeTableAdapter = new InsertAuditReportEmailListEmployeeEntryTableAdapters.QueriesTableAdapter();
                aInsertAuditReportEmailListEmployeeTableAdapter.InsertAuditReportEmailEmployee(intEmployeeID, strEmailAddress);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Audit Report Email List Class // Insert Audit Email List Employee " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public AuditReportEmailListDataSet GetAuditReportEmailListInfo()
        {
            try
            {
                aAuditReportEmailListDataSet = new AuditReportEmailListDataSet();
                aAuditReportEmailListTableAdapter = new AuditReportEmailListDataSetTableAdapters.auditreportemaillistTableAdapter();
                aAuditReportEmailListTableAdapter.Fill(aAuditReportEmailListDataSet.auditreportemaillist);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Audit Report Email List Class // Get Audit Report Email List Info " + Ex.Message);
            }

            return aAuditReportEmailListDataSet;
        }
        public void UpdateAuditReportEmailListDB(AuditReportEmailListDataSet aAuditReportEmailListDataSet)
        {
            try
            {
                aAuditReportEmailListTableAdapter = new AuditReportEmailListDataSetTableAdapters.auditreportemaillistTableAdapter();
                aAuditReportEmailListTableAdapter.Update(aAuditReportEmailListDataSet.auditreportemaillist);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Audit Report Email List Class // Update Audit Report Email List DB " + Ex.Message);
            }
        }
    }
}
