using SSM.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSM.Models;
namespace SSM.Models.Services
{
    public class CalendarService
    {
        public bool updateCalendar(String[] cells ,String userID) {
            try {
                CalendarRepo repo = new CalendarRepo(new SSMEntities());
                repo.deleteCalendarByUserID(userID);
               
                int[] ids = new int[cells.Length];
                for (int i = 0; i < cells.Length; i++) {
                    ids[i] = int.Parse(cells[i]);
                    System.Diagnostics.Debug.WriteLine("AAAAAAAAAA " + ids[i]);
                }
                repo.createNewCalendar(userID, ids);
                return true;
            }
            catch (Exception e) {

            }
            return false;

        }
        public List<MasterSchedule_User> getListOfUser(String userID) {
            SSMEntities se = new SSMEntities();
            return se.MasterSchedule_User.SqlQuery("SELECT * FROM MasterSchedule_User WHERE userID ='" + userID + "'").ToList();
            
        }
        public bool getScheduleByCell(int cellID,String userID)
        {
            SSMEntities se = new SSMEntities();
            List<MasterSchedule_User> lst = se.MasterSchedule_User.SqlQuery("SELECT * FROM  MasterSchedule_User WHERE userid='"+ userID + "' and scheduleID = " + cellID).ToList();
            if (lst.Count() > 0) return true;
            return false;
        }
    }
}