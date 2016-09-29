using SSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSM.Models.Repository
{
    public class CalendarRepo : IDisposable
    {
        SSMEntities context;
        public CalendarRepo(SSMEntities contextt)
        {
            context = contextt;
        }
        public List<MasterSchedule_User> getAll()
        {
            return context.MasterSchedule_User.ToList();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
       
        public MasterSchedule_User getById(int id)
        {

            return context.MasterSchedule_User.Find(id);
        }
        public void deleteCalendarByUserID(String userid) {
            try
            {
                List<MasterSchedule_User> lst = context.MasterSchedule_User.SqlQuery("SELECT * FROM MasterSchedule_User where userID='" + userid + "'").ToList();
                context.MasterSchedule_User.RemoveRange(lst);
                context.SaveChanges();
           
            }
            catch (Exception e) {
                
            }
         
        }
        public void createNewCalendar(String userID, int[] calendarids) {
            for (int i = 0; i < calendarids.Count(); i++) {
                MasterSchedule_User usercalendar = new MasterSchedule_User();
                usercalendar.userID = userID;
                usercalendar.scheduleID = calendarids[i];
                context.MasterSchedule_User.Add(usercalendar);
                context.SaveChanges();
            }
   
        }

    }
}